using Core.Requests.TransferModel;
using FluentValidation;

namespace Infrastructure.Validations;

public class CreateTransferRequestValidation : AbstractValidator<TransferRequest>
{
    public CreateTransferRequestValidation() {

        //d.1) Tiene que ser el mismo tipo de cuenta.
        //d.2) Debe ser la misma moneda.
        //d.3) El monto de transferencia no debe ser superior al saldo actual de la cuenta.
        //d.4) La cuenta de origen debe estar activa.
        //d.5) Verificar si la operación sobrepasa el límite operacional.

    }


}

