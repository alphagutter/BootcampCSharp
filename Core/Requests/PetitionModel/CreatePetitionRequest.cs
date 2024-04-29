
using Core.Constants;
using Core.Entities;
using Core.Requests.AccountModel.AccountTypesModel;
using Core.Requests.CreditCardModel;


namespace Core.Requests.PetitionModel;

    //necessary to create

public class CreatePetitionRequest
{
    public string Name { get; set; } = string.Empty;
    public string? Lastname { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    //public int CustomerId{ get; set; }
    public int CurrencyId { get; set; }
    public int ProductId { get; set; }
    public string? Description { get; set; }
}
