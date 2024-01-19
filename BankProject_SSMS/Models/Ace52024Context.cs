using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankProject_SSMS.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<PrernaSbaccount> PrernaSbaccounts { get; set; }

    public virtual DbSet<PrernaSbtransaction> PrernaSbtransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PrernaSbaccount>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__PrernaSB__BE2ACD6E1944D491");

            entity.ToTable("PrernaSBAccount");

            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CustomerAdress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PrernaSbtransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__PrernaSB__55433A6B244038C1");

            entity.ToTable("PrernaSBTransaction");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.PrernaSbtransactions)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("FK_PrernaSBTransaction_AccountNumber");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
