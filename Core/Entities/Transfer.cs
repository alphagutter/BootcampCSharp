
using Core.Constants;
using Core.Models;

namespace Core.Entities;

public class Transfer
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int OriginAccountId { get; set; }
    public Account OriginAccount { get; set; } = null!;
    public DateTime TransferredDateTime { get; set; }
    public string Description { get; set; } = string.Empty;
    //public int MovementId { get; set; }
    //public Movement Movement { get; set; } = null!;
    //public TransferType TransferType { get; set; } = TransferType.SameBank;
    public TransferStatus TransferStatus { get; set; } = TransferStatus.Pending;

    public int DestinationAccountId { get; set; }
    public Account? DestinationAccount { get; set; }

    //we don't use the Account data, instead of that, we just use its currency and bank
    public int DestinationBankId { get; set; }
    public Bank Bank { get; set; } = null!;
    public int DestinationCurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;
}
