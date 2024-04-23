
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.PaymentModel;
using Infrastructure.Contexts;
using Mapster;

namespace Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly BootcampContext _context;

    public PaymentRepository(BootcampContext context)
    {
        _context = context;
    }

    //not implemented yet
    public async Task<PaymentDTO> Add(CreatePaymentRequest request)
    {
        //searchs for the mapping configuration
        var paymenttocreate = request.Adapt<Payment>();

        //_context.Services.Add(servicetocreate);

        //await _context.SaveChangesAsync();

        ////adaptation

        //var serviceDTO = servicetocreate.Adapt<ServiceDTO>();


        //return serviceDTO;

        throw new NotImplementedException();

    }

    public async Task<PaymentDTO> GetById(int id)
    {
        var payment = await _context.Payments.FindAsync(id);

        if (payment is null) throw new NotFoundByIdException("Payment", id);

        //adapting paymentDTO

        var paymentDTO = payment.Adapt<PaymentDTO>();

        return paymentDTO;
    }
}
