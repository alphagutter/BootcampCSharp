using Core.Constants;
using Core.Entities;

namespace Core.Models;

public class TransferDTO
{
    public int Id { get; set; }
    public int OriginAccountId { get; set; }
    public AccountDTO OriginAccount { get; set; } = null!;
    public int DestinationAccountId { get; set; }
    public AccountDTO DestinationAccount { get; set; } = null!;
    public DateTime TransferredDateTime { get; set; }
    //public int MovementId { get; set; }
    //public MovementDTO Movement { get; set; } = null!;
    public TransferType TransferType { get; set; }
    public TransferStatus TransferStatus { get; set; }


    public decimal Amount { get; set; }
    public int BankId { get; set; }
    public BankDTO Bank { get; set; } = null!;
    public int CurrencyId { get; set; }
    public CurrencyDTO Currency { get; set; } = null!;
    public string Description { get; set; } = string.Empty;


}
