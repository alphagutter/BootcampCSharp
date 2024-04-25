

namespace Core.Requests.ExtractionModel;

public class CreateExtractionRequest
{
    public int AccountId { get; set; }
    public int BankId { get; set; }
    public decimal Amount { get; set; }
}
