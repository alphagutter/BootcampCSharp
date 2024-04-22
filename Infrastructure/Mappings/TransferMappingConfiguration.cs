using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests.TransferModel;
using Mapster;

public class TransferMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TransferRequest, Transfer>()
            .Map(dest => dest.OriginAccountId, src => src.OriginAccountId);

        config.NewConfig<TransferRequest, Movement>()
            .Map(dest => dest.Destination, src => src.AccountNumber)
            .Map(dest => dest.Amount, src => src.Amount)
            // Convertir el valor DateTime a UTC antes de asignarlo
            .Map(dest => dest.TransferredDateTime, src => DateTime.UtcNow)
            .Map(dest => dest.MovementType, src => MovementType.Transfer)
            .Map(dest => dest.OriginAccountId, src => src.OriginAccountId);

        config.NewConfig<Transfer, TransferDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.OriginAccountId, src => src.OriginAccountId)
            .Map(dest => dest.MovementId, src => src.MovementId)
            .Map(dest => dest.DestinationAccountId, src => src.DestinationAccountId)
            .Map(dest => dest.TransferStatus, src => TransferStatus.Done)
            .Map(dest => dest.DestinationAccount, src => src.OriginAccount.Adapt<AccountDTO>())
            .Map(dest => dest.Movement, src => src.Movement.Adapt<MovementDTO>())
            .Map(dest => dest.TransferredDateTime, src => DateTime.UtcNow);

    }
}
