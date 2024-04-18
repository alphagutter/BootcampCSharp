using Core.Constants;

namespace Core.Entities;

public class Petition
{
    public int Id { get; set; }
    public ProductType Type { get; set; }
    //the type of card
    public string Term { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime RequestDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public PetitionStatus Status { get; set; } = PetitionStatus.Pending;
    public int CurrencyId { get; set; }
    public Currency? Currency { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

}