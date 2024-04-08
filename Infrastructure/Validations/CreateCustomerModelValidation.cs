
using Core.Constants;
using Core.Models;
using Core.Requests.CustomerModel;
using FluentValidation;
using System;

namespace Infrastructure.Validations
{
    /// <summary>
    /// We create the validations for the creation of the models, it works to create more shortcuts and more legible code
    /// </summary>
    public class CreateCustomerModelValidation : AbstractValidator<CreateCustomerModel>
    {
        /// <summary>
        /// rules for creation of Bank Model
        /// </summary>
        public CreateCustomerModelValidation() {

           //validations for name
            RuleFor(x => x.Name)
            .NotNull().WithMessage("Name cannot be null")
            .NotEmpty().WithMessage("Name cannot be empty")
            .MinimumLength(5).WithMessage("Name must have at least 5 characters");

            //validations for DocumentNumber
            RuleFor(x => x.DocumentNumber)
                .NotNull().WithMessage("ID cannot be null")
                .NotEmpty().WithMessage("ID cannot be empty");

            //validations for mail
            RuleFor(x => x.Mail)
                .EmailAddress();

            //validations for CustomerStatus
            RuleFor(x => x.CustomerStatus)
                .NotNull().WithMessage("CustomerStatus cannot be null")
                .NotEmpty().WithMessage("CustomerStatus cannot be empty")
                .Must(x => Enum.IsDefined(typeof(CustomerStatus), x));


        }

        


    }
}
