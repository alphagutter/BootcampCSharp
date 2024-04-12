
using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests.AccountModel;
using Core.Requests.AccountModel.AccountTypeModel;
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
            .Map(dest => dest.Currency, src => src.CurrencyId)
            .Map(dest => dest.Customer, src => src.CustomerId)
            .Map(dest => dest.Status, src => src.Status);

    }

    //depending of which account we choose, it will call one of the DTO's and create the accouont type according to
    private object ChooseAccountType(string typeChoosed)
    {
        switch (typeChoosed)
        {
            case "Current":
                return CurrentCreation();
            case "SavingAccount":
                return SavingAccountCreation();
            default:
                throw new ArgumentException("Invalid account type");
        }
    }
