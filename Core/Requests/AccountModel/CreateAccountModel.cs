using Core.Constants;
using Core.Entities;
using Core.Models;

namespace Core.Requests.AccountModel;


/// <summary>
/// class where we create our customer
/// </summary>
public class CreateAccountModel
{
    public string Holder { get; set; } = string.Empty;                      //required
    public string Number { get; set; } = string.Empty;                      //required
    public string Type { get; set; } = string.Empty;                                 
    public int CurrencyId { get; set; }                         
    public int CustomerId { get; set; }                      
}
