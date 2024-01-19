using System;
using System.Collections.Generic;

namespace BankProject_SSMS.Models;

public partial class PrernaSbaccount
{
    public int AccountNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAdress { get; set; }

    public decimal? CurrentBalance { get; set; }

    public virtual ICollection<PrernaSbtransaction> PrernaSbtransactions { get; set; } = new List<PrernaSbtransaction>();
}
