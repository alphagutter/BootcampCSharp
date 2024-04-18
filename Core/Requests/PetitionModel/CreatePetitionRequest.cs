
using Core.Constants;
using Core.Entities;
using Core.Requests.AccountModel.AccountTypesModel;
using Core.Requests.CreditCardModel;


namespace Core.Requests.PetitionModel;

    //necessary to create

public class CreatePetitionRequest
{


    public decimal Amount { get; set; }
    public string Term { get; set; } = string.Empty;
    public DateTime RequestDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public ProductType Type { get; set; }
    public PetitionStatus Status { get; set; } = PetitionStatus.Pending;
    public int CustomerId { get; set; }
    public int CurrencyId { get; set; }
}
