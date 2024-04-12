
using Core.Constants;
using Core.Entities;

namespace Core.Models;

public class AccountDTO
{
    /// <summary>
    /// ????????
    /// </summary>
    public int Id { get; set; }
    public string Holder { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public Currency Currency { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
    public string Status { get; set; } = string.Empty;

    //it will filled, depending of the chosen type
    public SavingAccount? SavingAccount { get; set; }
    public CurrentAccount? CurrentAccount { get; set; }

}
