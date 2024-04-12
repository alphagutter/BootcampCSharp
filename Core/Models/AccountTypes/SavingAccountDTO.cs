
using Core.Entities;

namespace Core.Models.AccountTypes;
public class SavingAccountDTO
{
    public int Id { get; set; }
    public string SavingType { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;

    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
}