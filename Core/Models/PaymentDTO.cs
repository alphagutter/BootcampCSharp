
using Core.Entities;

namespace Core.Models;

public class PaymentDTO
{
    public int Id { get; set; }

    //we can get it from the Current(linking with the Account)
    public string DocumentNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public DateTime PaymentDateTime { get; set; }
    public AccountDTO OriginAccountDTO { get; set; } = null!;
    public ServiceDTO ServiceDTO { get; set; } = null!;

}
