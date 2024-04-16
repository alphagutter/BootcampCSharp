
using Core.Constants;
using Core.Entities;
using Core.Models.AccountTypes;
using Core.Requests.AccountModel.AccountTypesModel;
using Mapster;

namespace Infrastructure.Mappings;
/// <summary>
/// Configuration for SavingAccount Creation(template to create SavingAccount and SavingAccountDTO)
/// </summary>
public class SavingAccountConfiguration
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateSavingAccount, SavingAccount>()
            .Map(dest => dest.SavingType, src => Enum.Parse<SavingType>(src.SavingType))
            .Map(dest => dest.HolderName, src => src.HolderName)
            .Map(dest => dest.AccountId, src => src.AccountId);

        config.NewConfig<SavingAccount, SavingAccountDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.SavingType, src => src.SavingType)
            .Map(dest => dest.HolderName, src => src.HolderName)
            .Map(dest => dest.Account, src => src.Account);
    }

}
