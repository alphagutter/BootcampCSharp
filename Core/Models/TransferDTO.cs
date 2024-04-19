using Core.Constants;
using Core.Entities;

namespace Core.Models;

public class TransferDTO
{
    public int Id { get; set; }
    public TransferStatus TransferStatus { get; set; } = TransferStatus.Pending;
    public decimal Amount { get; set; }
    public int OriginAccountId { get; set; }
    public AccountDTO DestinationAccount { get; set; } = null!;
    public DateTime? TransferredDateTime { get; set; }
}
