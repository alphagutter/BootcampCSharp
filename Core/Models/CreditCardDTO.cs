
using Core.Constants;
using Core.Entities;

namespace Core.Models;

public class CreditCardDTO
{
    public int Id { get; set; }
    public string Designation { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public int Cvv { get; set; }
    public string CreditCardStatus { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
    public decimal AvailableCredit { get; set; }
    public decimal CurrentDebt { get; set; }
    public decimal InterestRate { get; set; }
    public CurrencyDTO Currency { get; set; } = null!;
    public CustomerDTO Customer { get; set; } = null!;

    //it shows the first 12 numbers of the creditcard, restrincted

    public string RestrictedCreditCard { get; set; } = string.Empty;
}
