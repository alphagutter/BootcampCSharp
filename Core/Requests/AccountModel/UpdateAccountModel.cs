
namespace Core.Requests.AccountModel;

public class UpdateAccountModel
{
    public int Id { get; set; }
    public string Holder { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public int CurrencyId { get; set; }
    public int CustomerId { get; set; }
    public string Status { get; set; } = string.Empty;

}
