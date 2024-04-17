using Core.Constants;

namespace Core.Entities;


/// <summary>
/// this class is for the product that the user will choose depending on its preference
/// </summary>
public class Product
{
    public int Id { get; set; }
    
    //for default, the type will be a Current Account
    public ProductType Type { get; set; } = ProductType.CurrentAccount;
    public DateTime ApplicationDate { get; set; }
    public DateTime ApprovalDate { get; set; }

    //the current type that the product will have
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; } = new Currency();


    //depending on which product type we choose, it will use one of this attributes
    public CreditCard? CreditCard { get; set; }
    public CurrentAccount? CurrentAccount { get; set; }
    public CreditOnly? CreditOnly { get; set; }





}
