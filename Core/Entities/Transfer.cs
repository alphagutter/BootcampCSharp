
using Core.Constants;
using Core.Models;

namespace Core.Entities;

public class Transfer
{
    public int Id { get; set; }
    public int OriginAccountId { get; set; }
    public Account OriginAccount { get; set; } = null!;
    public DateTime? TransferredDateTime { get; set; }
    public int MovementId { get; set; }
    public Movement Movement { get; set; } = null!;
    public TransferType TransferType { get; set; } = TransferType.SameBank;
    public TransferStatus TransferStatus { get; set; } = TransferStatus.Pending;

    public int DestinationAccountId { get; set; }
}
