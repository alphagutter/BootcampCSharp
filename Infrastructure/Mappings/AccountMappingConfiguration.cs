
using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests.AccountModel;
using Core.Requests.AccountModel.AccountTypesModel;
using Mapster;

namespace Infrastructure.Mappings;

/// <summary>
/// Configuration for Customer Creation(template to create Account and AccountDTO)
/// </summary>
public class AccountMappingConfiguration

{
    public void Register(TypeAdapterConfig config)
    {

        //origin to destination(CreateAccountModel to Account)
        config.NewConfig<CreateAccountModel, Account>()
            .Map(dest => dest.Holder, src => src.Holder)
            .Map(dest => dest.Number, src => src.Number)
            .Map(dest => dest.Type, src => Enum.Parse<AccountType>(src.Type))
            .Map(dest => dest.CurrencyId, src => src.CurrencyId)
            .Map(dest => dest.CustomerId, src => src.CustomerId);

        //origin to destination(Account to AccountDTO)
        config.NewConfig<Account, AccountDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Holder, src => src.Holder)
            .Map(dest => dest.Number, src => src.Number)
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.Balance, src => src.Balance)
            .Map(dest => dest.Currency, src => src.Currency)
            .Map(dest => dest.Customer, src => src.Customer)
            .Map(dest => dest.Status, src => src.Status)

            .Map(dest => dest.CurrentAccountDTO, src => src.CurrentAccount)
            .Map(dest => dest.SavingAccountDTO, src => src.SavingAccount);

        }
    }    