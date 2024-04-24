
using Core.Entities;

namespace Core.Models;

public class DepositDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime DepositDateTime { get; set; }
    // Otras propiedades del depósito
    public int AccountId { get; set; }
    public AccountDTO AccountDTO { get; set; } = null!;
    public int BankId { get; set; }
    public BankDTO Bank { get; set; } = null!;
}
