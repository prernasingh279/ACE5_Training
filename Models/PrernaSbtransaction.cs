using System;
using System.Collections.Generic;

namespace BankProject_SSMS.Models;

public partial class PrernaSbtransaction
{
    public int TransactionId { get; set; }

    public string? TransactionType { get; set; }

    public DateTime? TransactionDate { get; set; }

    public decimal? Amount { get; set; }

    public int? AccountNumber { get; set; }

    public virtual PrernaSbaccount? AccountNumberNavigation { get; set; }
}
