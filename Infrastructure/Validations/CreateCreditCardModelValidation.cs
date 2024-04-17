

using Core.Constants;
using Core.Models;
using Core.Requests.CreditCardModel;
using FluentValidation;

namespace Infrastructure.Validations;


/// <summary>
/// We create the validations for the creation of the models, it works to create more shortcuts and more legible code
/// </summary>
public class CreateCreditCardModelValidation : AbstractValidator<CreateCreditCardModel>
{
    /// <summary>
    /// rules for creation of Credit Card Model
    /// </summary>
    public CreateCreditCardModelValidation()
    {
        //for designation
        RuleFor(x => x.Designation)
            .NotNull().WithMessage("Designation cannot be null")
            .NotEmpty().WithMessage("Designation cannot be empty")
            .MinimumLength(10).WithMessage("Designation must have at least 10 characters");

        //for CardNumber
        RuleFor(x => x.CardNumber)
            .NotNull().WithMessage("CardNumber cannot be null")
            .NotEmpty().WithMessage("CardNumber cannot be empty")
            .Must(cardNumber => cardNumber.ToString().All(char.IsDigit) && cardNumber.ToString().Length == 16)
            .WithMessage("CardNumber must have 16 numbers");

        //for CVV
        RuleFor(x => x.Cvv)
             .NotNull().WithMessage("CVV cannot be null")
             .NotEmpty().WithMessage("CVV cannot be empty")
             .LessThan(999).WithMessage("CVV must be lower than 999");

        //for credit card status
        RuleFor(x => x.CreditCardStatus)
             .Must(x => Enum.IsDefined(typeof(CreditCardStatus), x))
             .WithMessage("Invalid CreditCard Status");

        //for credit limit
        RuleFor(x => x.CreditLimit)
            .NotNull().WithMessage("Credit Limit cannot be null")
            .GreaterThan(0).WithMessage("Credit Limit must be greater than zero.");

        //for available credit
        RuleFor(x => x.AvailableCredit)
            .NotNull().WithMessage("Available Credit cannot be null")
            .GreaterThan(500000).WithMessage("Interest must be greater than five hundred thousand.");

        //for interest rate
        RuleFor(x => x.InterestRate)
            .NotNull().WithMessage("Interest Rate cannot be null")
            .GreaterThan(0).WithMessage("Interest must be greater than zero.");
    }

}
