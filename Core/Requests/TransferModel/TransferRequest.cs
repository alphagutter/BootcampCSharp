using Core.Entities;

namespace Core.Requests.TransferModel;

public class TransferRequest
{
    public int OriginAccountId { get; set; }
    
    //it will not be necessary if the banks are the same for the origin and destination
    public Transfer? DestinationAccount {  get; set; }

    //only chargable if the bank is equal for origin and destination
    public int? DestinationId { get; set; }

    public decimal Amount { get; set; }
}
