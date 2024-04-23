
using Core.Entities;

namespace Core.Requests.DepositModel;

public class CreateDepositModel
{
    public decimal Amount { get; set; }
    public DateTime DepositDateTime { get; set; }
    // Otras propiedades del depósito
    public int AccountId { get; set; }
}
