using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Requests.ExtractionModel;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Principal;

namespace Infrastructure.Repositories;

public class ExtractionRepository : IExtractionRepository
{
    private readonly BootcampContext _context;

    public ExtractionRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<ExtractionDTO> Add(CreateExtractionRequest request)
    {
        var extraction = request.Adapt<Extraction>();

        _context.Extractions.Add(extraction);

        var originalAccount = await _context.Accounts
                                    .Include(a => a.Currency)
                                    .Include(a => a.Customer)
                                    .ThenInclude(c => c.Bank)
                                    .Include(a => a.SavingAccount)
                                    .Include(a => a.CurrentAccount)
                                    .FirstOrDefaultAsync(a => a.Id == request.AccountId);

        if (originalAccount == null) throw new NotFoundByIdException("Account", request.AccountId);

                    //Basic Validations
        if(request.Amount <= 0)
        {
            throw new Exception("the Amount can not be 0 or negative");
        }

        if (originalAccount.Balance < request.Amount)
        {
            throw new Exception("Balance insufficient");
        }

        if (originalAccount.Customer.BankId != request.BankId)
        {
            throw new Exception("The bank does not match for the customer");
        }


        if (originalAccount.CurrentAccount != null && request.Amount > originalAccount.CurrentAccount.OperationalLimit)
        {
            throw new NotFoundException("The operation exceeds the operational limit.");
        }

        var totalAmountOperationsOATransfers = _context.Transfers
                                                 .Where(t => t.OriginAccountId == originalAccount.Id &&
                                                 t.TransferredDateTime.Month == DateTime.Now.Month)
                                                 .Sum(t => t.Amount);

        var totalAmountOperationsDATransfers = _context.Transfers
                                                 .Where(t => t.DestinationAccountId == originalAccount.Id &&
                                                 t.TransferredDateTime.Month == DateTime.Now.Month)
                                                 .Sum(t => t.Amount);

        var totalAmountOperationsDeposits = _context.Deposits
                                                 .Where(d => d.AccountId == originalAccount.Id &&
                                                 d.DepositDateTime.Month == DateTime.Now.Month)
                                                 .Sum(d => d.Amount);

        var totalAmountOperationsExtractions = _context.Extractions
                                                 .Where(e => e.AccountId == originalAccount.Id &&
                                                 e.ExtractionDateTime.Month == DateTime.Now.Month)
                                                 .Sum(e => e.Amount);

        var totalAmountOperations = totalAmountOperationsOATransfers + totalAmountOperationsDATransfers + 
            totalAmountOperationsDeposits + totalAmountOperationsExtractions;

        if ((request.Amount + totalAmountOperations) > originalAccount.CurrentAccount!.OperationalLimit)
        {
            throw new NotFoundException("The operation exceeds the TOTAL operational limit.");
        }





        originalAccount.Balance -= request.Amount;

        await _context.SaveChangesAsync();

        var createExtraction = await _context.Extractions
            .FirstOrDefaultAsync(a => a.Id == extraction.Id);

        return createExtraction.Adapt<ExtractionDTO>();
    }

    public async Task<ExtractionDTO> GetById(int id)
    {
        var extraction = await _context.Extractions
            .Include(a => a.Account)
            .Include(a => a.Bank)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (extraction is null) throw new NotFoundByIdException("Extraction", id);

        return extraction.Adapt<ExtractionDTO>();
    }
}
