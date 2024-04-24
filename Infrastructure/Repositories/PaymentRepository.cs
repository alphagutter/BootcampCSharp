﻿
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

    //not implemented yet
    public async Task<PaymentDTO> Add(CreatePaymentRequest request)
    {
        var payment = request.Adapt<Payment>();

        var accountforDTO = await _context.Accounts.FindAsync(payment.OriginAccountId);
        var serviceforDTO = await _context.Services.FindAsync(payment.ServiceId);


        var account = await _context.Accounts
                                      .Include(a => a.Customer)
                                      .ThenInclude(c => c.Bank)
                                      .Include(a => a.Currency)
                                      .Include(a => a.CurrentAccount)
                                      .FirstOrDefaultAsync(a => a.Id == request.OriginAccountId);


        if (account == null) throw new NotFoundByIdException("Account", request.OriginAccountId);

        account.Balance = account.Balance - request.Amount;
        _context.Accounts.Update(account);

        _context.Payments.Add(payment);

        await _context.SaveChangesAsync();

        var paymentDTO = await _context.Payments
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
