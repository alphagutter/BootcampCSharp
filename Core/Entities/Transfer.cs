
using Core.Constants;
using Core.Models;

namespace Core.Entities;

public class Transfer
{
    public int Id { get; set; }
    public TransferStatus TransferStatus { get; set; } = TransferStatus.Pending;
    public decimal Amount { get; set; }
    public int OriginAccountId { get; set; }
    public Account DestinationAccount { get; set; } = null!;
    public DateTime? TransferredDateTime { get; set; }

    public ICollection<AccountTransfer> AccountTransfers { get; set;} = new List<AccountTransfer>();
}
