
using Core.Entities;

namespace Core.Requests.DepositModel;

public class CreateDepositModel
{
    public int BankId { get; set; }
    public int AccountId { get; set; }
    public decimal Amount { get; set; }
}
