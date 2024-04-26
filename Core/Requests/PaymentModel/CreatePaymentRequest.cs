
using Core.Entities;

namespace Core.Requests.PaymentModel;

public class CreatePaymentRequest
{
    //we can get it from the Current(linking with the Account)
    public int OriginAccountId { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public int ServiceId { get; set; }
}
