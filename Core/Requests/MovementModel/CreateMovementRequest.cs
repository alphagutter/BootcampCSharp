using Core.Constants;
using Core.Entities;

namespace Core.Requests.MovementModel;

public class CreateMovementRequest
{
    public MovementType MovementType { get; set; } = MovementType.Transfer;
    public decimal Amount { get; set; }
    public DateTime? TransferredDateTime { get; set; }
    public TransferStatus TransferStatus { get; set; } = TransferStatus.Pending;


    public int OriginAccountId { get; set; }
    public int DestinationAccountId { get; set; }
}