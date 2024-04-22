using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.TransferModel;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Core.Exceptions;

namespace Infrastructure.Repositories;
public class TransferRepository : ITransferRepository
{
    private readonly BootcampContext _transfercontext;
    public TransferRepository(BootcampContext bootcampcontext)
    {
        _transfercontext = bootcampcontext;
        
    }


    public async Task<TransferDTO> Transfer(TransferRequest request)
    {
        var transfer = request.Adapt<Transfer>();
        transfer.Movement = request.Adapt<Movement>();

        var originAccount = await _transfercontext.Accounts
                                          .Include(a => a.Customer)
                                          .ThenInclude(c => c.Bank)
                                          .Include(a => a.CurrentAccount)
                                          .Include(a => a.Currency)
                                          .FirstOrDefaultAsync(a => a.Id == request.OriginAccountId);

        var destinationAccount = await _transfercontext.Accounts
                                              .Include(a => a.Customer)
                                              .ThenInclude(c => c.Bank)
                                              .Include(a => a.Currency)
                                              .FirstOrDefaultAsync(a =>
                                              (a.Number == request.AccountNumber) &&
                                              (a.Customer.DocumentNumber == request.DocumentNumber));

        if (originAccount is null || destinationAccount is null)
        {
            throw new Exception("Account must exist.");
        }






        //it validates the accounts requirements for the transaction
        var flag = ValidateAccounts(originAccount, destinationAccount, request.Amount);


        if (flag == true)
        {
            //we make the balance
            originAccount.Balance = originAccount.Balance - request.Amount;
            _transfercontext.Accounts.Update(originAccount);

            destinationAccount.Balance = destinationAccount.Balance + request.Amount;
            _transfercontext.Accounts.Update(destinationAccount);

            var newMovementId = _transfercontext.Movements.Count() == 0 ? 1 : _transfercontext.Movements.Max(c => c.Id) + 1;
            transfer.Id = newMovementId;

            _transfercontext.Movements.Add(transfer.Movement);

            transfer.DestinationAccountId = destinationAccount.Id;
            transfer.MovementId = newMovementId;
            _transfercontext.Transfers.Add(transfer);

            await _transfercontext.SaveChangesAsync();


        }
        else
        {
            throw new TransferErrorException();
        }

            var createTransfer = await _transfercontext.Transfers
                                               .Include(t => t.Movement)
                                               .FirstOrDefaultAsync(t => t.Id == transfer.Id);


            createTransfer!.Movement.Account = originAccount;
            createTransfer!.OriginAccount = destinationAccount;

            return createTransfer.Adapt<TransferDTO>();



    }

    public bool ValidateAccounts(Account originAccount, Account destinationAccount, decimal amount)
    {

        if (originAccount.Type != destinationAccount.Type)
        {
            throw new Exception("It has to be the same type of account.");
        }

        if (originAccount.CurrencyId != destinationAccount.CurrencyId)
        {
            throw new Exception("It must be the same currency.");
        }

        if (amount > originAccount.Balance)
        {
            throw new Exception("The transfer amount must not be greater than the current account balance.");
        }

        if (originAccount.Status == AccountStatus.Inactive ||
            destinationAccount.Status == AccountStatus.Inactive)
        {
            throw new Exception("Both Accounts must be active.");
        }

        if (originAccount.CurrentAccount != null && amount > originAccount.CurrentAccount.OperationalLimit)
        {
            throw new Exception("The operation exceeds the operational limit.");
        }

        return true;
    }

}