
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
            .NotEqual(default(int)).WithMessage("CurrencyId can not be default")
            .NotEmpty().WithMessage("DocumentNumber is required");

        RuleFor(petition => petition.DocumentNumber)
            .NotEqual(default(string)).WithMessage("DocumentNumber can not be default")
            .NotEmpty().WithMessage("DocumentNumber is required");

        RuleFor(petition => petition.ProductId)
            .NotEqual(default(int)).WithMessage("ProductId can not be default")
            .NotEmpty().WithMessage("Product is required");
    }

}   