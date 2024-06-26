﻿using Core.Constants;

namespace Core.Entities;

public class Account
{
    public int Id { get; set; }
    public string Holder { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public AccountType Type { get; set; }
    public decimal Balance { get; set; }
    public AccountStatus Status { get; set; } = AccountStatus.Active;
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public IsDeletedStatus IsDeleted { get; set; } = IsDeletedStatus.False;
    public SavingAccount? SavingAccount { get; set; }
    public CurrentAccount? CurrentAccount { get; set; }

    //recently added
    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
    public virtual ICollection<Extraction> Extractions { get; set; } = new List<Extraction>();



}
