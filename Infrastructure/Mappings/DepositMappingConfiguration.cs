using Core.Entities;
using Core.Models;
using Core.Constants;
using Core.Requests.DepositModel;
using Mapster;
using Core.Requests.CreditCardModel;

namespace Infrastructure.Mappings;

/// <summary>d
/// Configuration for Deposit Creation(template to create Deposit and DepositDTO)
/// </summary>
public class DepositMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //origin to destination(CreateDepositModel to Deposit)
        config.NewConfig<CreateDepositModel, Deposit>()
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.DepositDateTime, src => DateTime.UtcNow)
            .Map(dest => dest.AccountId, src => src.AccountId)
            .Map(dest => dest.BankId, src => src.BankId);


        config.NewConfig<Deposit, DepositDTO>()
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.DepositDateTime, src => src.DepositDateTime)
            .Map(dest => dest.AccountDTO, src => src.Account)
            .Map(dest => dest.Bank, src => src.Bank);



    }

}