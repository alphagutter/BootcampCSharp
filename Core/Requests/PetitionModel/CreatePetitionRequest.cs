
using Core.Constants;
using Core.Entities;
using Core.Requests.AccountModel.AccountTypesModel;
using Core.Requests.CreditCardModel;


namespace Core.Requests.PetitionModel;

    //necessary to create

public class CreatePetitionRequest
{
    public DateTime RequestDate { get; set; }
    
    //the user will (obviously) not be allowed to select his own approval date
    //public DateTime? ApprovalDate { get; set; }
    public ProductType Type { get; set; }
    public PetitionStatus Status { get; set; } = PetitionStatus.Pending;
    
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int CurrencyId { get; set; }
}
