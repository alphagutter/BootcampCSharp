
using Core.Entities;
using Core.Requests;
using Core.Requests.PetitionModel;
using FluentValidation;

namespace Infrastructure.Validetions;

public class CreatePetitionRequestValidation : AbstractValidator<CreatePetitionRequest>
{
    public CreatePetitionRequestValidation()
    {
        RuleFor(petition => petition.CurrencyId)
            .NotEqual(default(int)).WithMessage("CurrencyId can not be default");

        RuleFor(petition => petition.CustomerId)
            .NotEqual(default(int)).WithMessage("CurrencyId can not be default");

        RuleFor(petition => petition.ProductId)
            .NotEqual(default(int)).WithMessage("ProductId can not be default");
    }

}   