
using Core.Constants;

namespace Core.Models;

public class PetitionDTO
{
    public int Id { get; set; }
       
    public DateTime RequestDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string ProductType { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Currency { get; set; } = null!;
    public string Customer { get; set; } = null!;

}