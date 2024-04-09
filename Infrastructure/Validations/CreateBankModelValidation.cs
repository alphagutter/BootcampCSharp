
using Core.Requests.BankModel;
using FluentValidation;

namespace Infrastructure.Validations;

/// <summary>
/// We create the validations for the creation of the models, it works to create more shortcuts and more legible code
/// </summary>
public class CreateBankModelValidation : AbstractValidator<CreateBankModel>
{
    /// <summary>
    /// rules for creation of Bank Model
    /// </summary>
    public CreateBankModelValidation() {

       //validations for name
        RuleFor(x => x.Name)
        .NotNull().WithMessage("Name cannot be null")
        .NotEmpty().WithMessage("Name cannot be empty")
        .MinimumLength(5).WithMessage("Name must have at least 5 characters");

        //validations for mail
        RuleFor(x => x.Mail)
            .EmailAddress();

        //validations for Phone
        RuleFor(x => x.Phone)
            .NotNull().WithMessage("Phone cannot be null")
            .NotEmpty().WithMessage("Phone cannot be empty");
    }
}
