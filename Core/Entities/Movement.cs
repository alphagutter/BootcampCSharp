using Core.Constants;

namespace Core.Entities;

public class Movement
{
    public int Id { get; set; }
    public string Destination { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime? TransferredDateTime { get; set; }
    public MovementType MovementType { get; set; } = MovementType.Transfer;
    public int OriginAccountId { get; set; }  
    public int DestinationAccountId { get; set; }  
    
    //the origin account
    public virtual Account Account { get; set; } = null!;
}