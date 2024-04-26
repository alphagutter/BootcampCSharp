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
            .Map(dest => dest.OriginAccountId, src => src.OriginAccountId)
            .Map(dest => dest.DestinationBankId, src => src.DestinationBankId)
            .Map(dest => dest.DestinationCurrencyId, src => src.DestinationCurrencyId)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransferredDateTime, src => DateTime.UtcNow)
            .Map(dest => dest.Description, src => src.Description);


        config.NewConfig<Transfer, TransferDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransferredDateTime, src => src.TransferredDateTime)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.OriginAccount, src => src.OriginAccount)
            .Map(dest => dest.DestinationAccount, src => src.DestinationAccount)
            .Map(dest => dest.Bank, src => src.Bank)
            .Map(dest => dest.Currency, src => src.Currency);

    }
}
