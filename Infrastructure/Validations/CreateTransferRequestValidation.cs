using Core.Requests.TransferModel;
using FluentValidation;

namespace Infrastructure.Validations;

public class CreateTransferRequestValidation : AbstractValidator<TransferRequest>
{
    public CreateTransferRequestValidation() {

        RuleFor(request => request.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0.");

        RuleFor(request => request.DestinationAccountId).NotEmpty().WithMessage("Document number is required.");

        RuleFor(request => request.OriginAccountId).NotEmpty().WithMessage("Origin account ID is required.");

    }


}

