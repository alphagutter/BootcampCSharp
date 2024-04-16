
using Core.Constants;
using Core.Entities;
using Core.Models.AccountTypes;
namespace Core.Models;

public class AccountDTO
{
    public int Id { get; set; }
    public string Holder { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public AccountType Type { get; set; } = AccountType.Current;
    public CurrencyDTO Currency { get; set; } = null!;
    public CustomerDTO Customer { get; set; } = null!;
    public string Status { get; set; } = string.Empty;

    //it will filled, depending of the chosen type
    public SavingAccountDTO? SavingAccount { get; set; }
    public CurrentAccountDTO? CurrentAccount { get; set; }

}
