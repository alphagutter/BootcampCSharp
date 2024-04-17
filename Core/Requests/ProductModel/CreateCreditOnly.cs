
namespace Core.Requests.ProductModel;

public class CreateCreditOnly
{
    public decimal Amount { get; set; }

    //this terms are accounted for months
    public int Terms { get; set; }
}
