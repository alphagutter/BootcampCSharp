
namespace Core.Entities;

//Payment utilities are for connecting with a Service
public class Payment
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public int OriginAccountId { get; set; }
    public Account OriginAccount { get; set; } = null!;
    public DateTime PaymentDateTime { get; set; }

    //we can get it from the Current(linking with the Account)
    public string DocumentNumber { get; set; } = string.Empty;
    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;


}
