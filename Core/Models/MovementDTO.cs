

using Core.Constants;
using Core.Entities;

namespace Core.Models;

public class MovementDTO
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string MovementType { get; set; } = string.Empty;
    public int OriginAccountId { get; set; }
    public int DestinationAccountId { get; set; }

    //the origin account
    public Account Account { get; set; } = null!;
}