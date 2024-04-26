
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.PaymentModel;
using Infrastructure.Contexts;
using Infrastructure.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly BootcampContext _context;

    public PaymentRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<PaymentDTO> Add(CreatePaymentRequest request)
    {
        //we map the payment entity
        var payment = request.Adapt<Payment>();

        //to see the account and service for the payment, we need to call it individually
        var accountforDTO = await _context.Accounts.FindAsync(payment.OriginAccountId);
        var serviceforDTO = await _context.Services.FindAsync(payment.ServiceId);


        var account = await _context.Accounts
                                      .Include(a => a.Customer)
                                      .ThenInclude(c => c.Bank)
                                      .Include(a => a.Currency)
                                      .Include(a => a.CurrentAccount)
                                      .FirstOrDefaultAsync(a => a.Id == request.OriginAccountId
                                      && a.Customer.DocumentNumber == request.DocumentNumber
                                      );


        if (account == null) throw new NotFoundByIdException("Account", request.OriginAccountId);
        if (serviceforDTO == null) throw new Exception("Service does not exist");


                                //Basic Validations
        if (request.Amount <= 0)
        {
            throw new Exception("the Amount can not be 0 or negative");
        }

        if (account.Balance < request.Amount)
        {
            throw new Exception("Balance insufficient");
        }


        //we substract the amount specified for the user
        account.Balance = account.Balance - request.Amount;
        _context.Accounts.Update(account);

        _context.Payments.Add(payment);

        await _context.SaveChangesAsync();

        var paymentDTO = await _context.Payments
            .Include(p => p.OriginAccount)
            .ThenInclude(oa => oa.Currency)
            .Include(p => p.OriginAccount)
            .ThenInclude(oa => oa.Customer)
            .ThenInclude(c => c.Bank)
            .FirstOrDefaultAsync(t => t.Id == payment.Id);

        return paymentDTO.Adapt<PaymentDTO>();

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
