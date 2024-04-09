using System;

using Core.Constants;
using Core.Models;
using Core.Requests.CurrencyModel;
using FluentValidation;
using System;

namespace Infrastructure.Validations;

/// <summary>
/// We create the validations for the creation of the models, it works to create more shortcuts and more legible code
/// </summary>
public class CreateCurrencyModelValidation : AbstractValidator<CreateCurrencyModel>
{
    /// <summary>
    /// rules for creation of Currency Model
    /// </summary>
    public CreateCurrencyModelValidation()
    {

        //validations for name
        RuleFor(x => x.Name)
        .NotNull().WithMessage("Name cannot be null")
        .NotEmpty().WithMessage("Name cannot be empty")
        .MinimumLength(5).WithMessage("Name must have at least 5 characters");


    }




}