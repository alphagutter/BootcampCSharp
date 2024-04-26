using Core.Constants;
using Core.Entities;

namespace Core.Requests.TransferModel;

public class TransferRequest
{
    public int OriginAccountId { get; set; }
    public int DestinationAccountId { get; set; }
    public string? DestinationDocumentNumber { get; set; }
    public int? DestinationBankId { get; set; }
    public int? DestinationCurrencyId { get; set; }
    public TransferType TransferType { get; set; }
    //it will not be necessary if the banks are the same for the origin and destination
    //only chargable if the bank is equal for origin and destination
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;

}
