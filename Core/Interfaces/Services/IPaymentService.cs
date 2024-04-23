
using Core.Models;
using Core.Requests.PaymentModel;

namespace Core.Interfaces.Services;
public interface IPaymentService
{
    Task<PaymentDTO> Add(CreatePaymentRequest request);
    Task<PaymentDTO> GetById(int id);
}
