
using Core.Constants;
using Core.Entities;
using Core.Models.AccountTypes;

namespace Core.Models;

public class AccountDTO
{
    public int Id { get; set; }
    public string Holder { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public CurrencyDTO Currency { get; set; } = null!;
    public CustomerDTO Customer { get; set; } = null!;
    public string Status { get; set; } = string.Empty;

    //it will filled, depending of the chosen type
    public SavingAccountDTO? SavingAccountDTO { get; set; }
    public CurrentAccountDTO? CurrentAccountDTO { get; set; }

}
