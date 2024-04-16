
using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Models.AccountTypes;
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

        //origin to destination(CreateAccountRequest to Account)
        config.NewConfig<CreateAccountRequest, Account>()
        .Map(dest => dest.Holder, src => src.Holder)
        .Map(dest => dest.Number, src => src.Number)
        .Map(dest => dest.Type, src => src.AccountType)
        .Map(dest => dest.CurrencyId, src => src.CurrencyId)
        .Map(dest => dest.CustomerId, src => src.CustomerId);


        //origin to destination(CreateSavingAccount to SavingAccount)
        config.NewConfig<CreateSavingAccount, SavingAccount>()
        .Map(dest => dest.SavingType, src => src.SavingType);

        //origin to destination(CreateCurrentAccount to CurrentAccount)
        config.NewConfig<CreateCurrentAccount, CurrentAccount>()
        .Map(dest => dest.OperationalLimit, src => src.OperationalLimit)
        .Map(dest => dest.MonthAverage, src => src.MonthAverage)
        .Map(dest => dest.Interest, src => src.Interest);


        //origin to destination(Account to AccountDTO)
        config.NewConfig<Account, AccountDTO>()
        .Map(dest => dest.Id, src => src.Id)
        .Map(dest => dest.Holder, src => src.Holder)
        .Map(dest => dest.Number, src => src.Number)
        .Map(dest => dest.Type, src => src.Type)
        .Map(dest => dest.Balance, src => src.Balance)
        .Map(dest => dest.Status, src => src.Status.ToString())
        .Map(dest => dest.Currency, src => src.Currency)
        .Map(dest => dest.Customer, src => src.Customer)
           .Map(dest => dest.SavingAccount, src =>
                src.SavingAccount != null
                ? src.SavingAccount
                : null)
            .Map(dest => dest.CurrentAccount, src =>
                src.CurrentAccount != null
                ? src.CurrentAccount
                : null);


        //origin to destination(SavingAccount to SavingAccountDTO)
        config.NewConfig<SavingAccount, SavingAccountDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.SavingType, src => src.SavingType.ToString());

        //origin to destination(CurrentAccount to CurrentAccountDTO)
        config.NewConfig<CurrentAccount, CurrentAccountDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.OperationalLimit, src => src.OperationalLimit)
            .Map(dest => dest.MonthAverage, src => src.MonthAverage)
            .Map(dest => dest.Interest, src => src.Interest);
    }
}    