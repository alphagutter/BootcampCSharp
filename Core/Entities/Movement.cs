using Core.Constants;

namespace Core.Entities;

public class Movement
{
    public int Id { get; set; }
    
    //we replace this useless string, to made attributes for origin a destination 
    //public string Destination { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public MovementType MovementType { get; set; } = MovementType.Transfer;
    public DateTime? TransferredDateTime { get; set; }
    public TransferStatus TransferStatus { get; set; } = TransferStatus.Pending;

    public int OriginAccountId { get; set; }
    public int DestinationAccountId { get; set; }

    //we only use one Account attribute, it is not necessary to make the logic with 2 of them
    public Account Account { get; set; } = null!;
}