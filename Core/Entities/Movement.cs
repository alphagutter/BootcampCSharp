using Core.Constants;

namespace Core.Entities;

public class Movement
{
    public int Id { get; set; }
    public string Destination { get; set; } = string.Empty;
    public decimal Amount { get; set; }

    public DateTime? TransferredDateTime { get; set; }                          //autochargable
    public TransferStatus TransferStatus { get; set; } = TransferStatus.Pending;


    //foreign key
    public int AccountId { get; set; }

    //object
    public Account Account { get; set; } = null!;
}
