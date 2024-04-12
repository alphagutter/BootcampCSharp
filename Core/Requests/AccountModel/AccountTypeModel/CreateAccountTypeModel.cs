using Core.Entities;
namespace Core.Requests.AccountModel.AccountTypeModel;



//not implemented yet
public class CreateAccountTypeModel
{
    public CurrentAccount CurrentCreation()
    {
        CurrentAccount newCurrentAccount = new CurrentAccount();
        return newCurrentAccount;
    }

    public SavingAccount SavingAccountCreation()
    {
        SavingAccount newSavingAccount = new SavingAccount();
        return newSavingAccount;
    }
}
