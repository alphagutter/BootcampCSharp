﻿namespace Core.Entities;

public class Bank
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    //added recently
    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();
    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
    public virtual ICollection<Extraction> Extractions { get; set; } = new List<Extraction>();
}