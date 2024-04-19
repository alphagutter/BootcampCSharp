

using Core.Constants;
using Core.Entities;

namespace Core.Models;

public class MovementDTO
{
    public int Id { get; set; }
    public MovementType MovementType { get; set; } = MovementType.Transfer;
    public decimal Amount { get; set; }
    public DateTime? TransferredDateTime { get; set; }
    public TransferStatus TransferStatus { get; set; } = TransferStatus.Pending;


    public int OriginAccountId { get; set; }
    public int DestinationAccountId { get; set; }
    public Account Account { get; set; } = null!;
}