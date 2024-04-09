
namespace Core.Requests.CurrencyModel;


/// <summary>
/// class where we create our currency
/// </summary>
public class CreateCurrencyModel
{
    public string Name { get; set; } = string.Empty;                //required
    public decimal? BuyValue { get; set; }
    public decimal? SellValue { get; set; }
}
