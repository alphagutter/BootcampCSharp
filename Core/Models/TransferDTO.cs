using Core.Constants;
using Core.Entities;

namespace Core.Models;

public class TransferDTO
{
    public int Id { get; set; }
    public int OriginAccountId { get; set; }
    public AccountDTO DestinationAccount { get; set; } = null!;
    public DateTime? TransferredDateTime { get; set; }
    public int MovementId { get; set; }
    public MovementDTO Movement { get; set; } = null!;
    public TransferType TransferType { get; set; }
    public TransferStatus TransferStatus { get; set; }
    public int DestinationAccountId { get; set; }
    public AccountDTO DestinationAccount { get; set; } = null!;

}
