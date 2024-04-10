using Core.Models;

namespace Core.Requests.CreditCardModel;
public class FiltersCreditCardModel
{
    //it will bring back the credit card providing its id
    public int? ByCreditCardId { get; set; }

    //it will bring back the credit card providing the credit card front text
    public string? ByDesignation { get; set; }

    //it will bring back the credit card data providing the customer name
    public string? ByCustomerName { get; set;}

}

