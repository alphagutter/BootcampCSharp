using Core.Models;
using Core.Requests.PaymentModel;

namespace Core.Interfaces.Repositories;

public interface IPaymentRepository
{
    Task<PaymentDTO> Add(CreatePaymentRequest model);
    Task<PaymentDTO> GetById(int id);
}