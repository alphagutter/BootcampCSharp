using Core.Constants;
using Core.Entities;

namespace Core.Requests.MovementModel;

public class CreateMovementRequest
{
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string MovementType { get; set; } = string.Empty;
    public int OriginAccountId { get; set; }
    public int DestinationAccountId { get; set; }
}