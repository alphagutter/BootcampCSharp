using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests.AccountModel.AccountTypesModel;             //for the account types

namespace Core.Requests.AccountModel;


/// <summary>
/// class where we request our customer
/// </summary>
public class CreateAccountRequest
{
    public string Holder { get; set; } = string.Empty;                      //required
    public string Number { get; set; } = string.Empty;                      //required
    public AccountType AccountType { get; set; }
    public int CustomerId { get; set; }
    public int CurrencyId { get; set; }

    public CreateSavingAccount? CreateSavingAccount { get; set; }
    public CreateCurrentAccount? CreateCurrentAccount { get; set; }
}
