
using Core.Constants;

namespace Core.Models;

public class PetitionDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    
    //the type of card
    public string Term { get; set; } = string.Empty;
    public DateTime RequestDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public ProductType ProductType { get; set; }
    public PetitionStatus Status { get; set; } = PetitionStatus.Pending;
    public CurrencyDTO Currency { get; set; } = null!;
    public CustomerDTO Customer { get; set; } = null!;

}