
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.PaymentModel;

namespace Infrastructure.Services;


/// <summary>
/// Constructors from all the services to use in the Payments Table
/// </summary>
public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repository;


    public async Task<PaymentDTO> Add(CreatePaymentRequest request)
    {

        return await _repository.Add(request);
    }

    public async Task<PaymentDTO> GetById(int id)
    {
        return await _repository.GetById(id);
    }
}