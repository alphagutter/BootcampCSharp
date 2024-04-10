using Core.Constants;
using Core.Models;

namespace Core.Requests.CreditCardModel;


/// <summary>
/// class where we create our creditcard
/// </summary>
public class CreateCreditCardModel
{
    public string Designation { get; set; } = string.Empty;                                 //required
    public DateTime IssueDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string CardNumber { get; set; } = string.Empty;                                  //required
    public int Cvv { get; set; }
    public string CreditCardStatus { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
    public decimal AvailableCredit { get; set; }
    public decimal CurrentDebt { get; set; }
    public decimal InterestRate { get; set; }
    public int CurrencyId { get; set; }
    public int CustomerId{ get; set; }


}
