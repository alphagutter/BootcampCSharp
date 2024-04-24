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
            .Map(dest => dest.BankId, src => src.BankId)
            .Map(dest => dest.CurrencyId, src => src.CurrencyId)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransferredDateTime, src => DateTime.UtcNow)
            .Map(dest => dest.Description, src => src.Description);


        config.NewConfig<Transfer, TransferDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransferredDateTime, src => src.TransferredDateTime)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.OriginAccount, src => src.OriginAccount)
            .Map(dest => dest.Bank, src => src.Bank)
            .Map(dest => dest.Currency, src => src.Currency);

    }
}
