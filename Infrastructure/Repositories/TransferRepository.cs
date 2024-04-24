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

        if (originAccount == null || destinationAccount == null)
        {
            throw new Exception("Both Accounts must exist.");
        }






        //it validates the accounts requirements for the transaction
        var flag = ValidateAccounts(originAccount, destinationAccount, request.Amount);


        if (flag == true)
        {
            ////we make the balance
            //originAccount.Balance = originAccount.Balance - request.Amount;
            //_transfercontext.Accounts.Update(originAccount);

            //destinationAccount.Balance = destinationAccount.Balance + request.Amount;
            //_transfercontext.Accounts.Update(destinationAccount);

            //var newMovementId = _transfercontext.Movements.Count() == 0 ? 1 : _transfercontext.Movements.Max(c => c.Id) + 1;
            //transfer.Id = newMovementId;

            //_transfercontext.Movements.Add(transfer.Movement);

            //transfer.DestinationAccountId = destinationAccount.Id;
            //transfer.MovementId = newMovementId;
            //_transfercontext.Transfers.Add(transfer);

            //await _transfercontext.SaveChangesAsync();


                //we change the balances for the accounts
                originAccount.Balance = originAccount.Balance - request.Amount;
                    _transfercontext.Accounts.Update(originAccount);

                destinationAccount.Balance = destinationAccount.Balance + request.Amount;
                    _transfercontext.Accounts.Update(destinationAccount);

                
                //it adds the destination account id to the transfer
                transfer.DestinationAccountId = destinationAccount.Id;
                    _transfercontext.Transfers.Add(transfer);

                await _transfercontext.SaveChangesAsync();

             var transferDTO = await _transfercontext.Transfers
                .FirstOrDefaultAsync(t => t.Id == transfer.Id);

            return transferDTO.Adapt<TransferDTO>();
        }
        else
        {
            throw new TransferErrorException();
        }





    }


    //It will check every validation it needs to Make the Transfers between Accounts    
    public bool ValidateAccounts(Account originAccount, Account destinationAccount, decimal amount)
    {

        if (originAccount.Type != destinationAccount.Type)
        {
            throw new Exception("It has to be the same account type.");
        }

        if (originAccount.CurrencyId != destinationAccount.CurrencyId)
        {
            throw new Exception("It must be the same currency.");
        }

        if (amount > originAccount.Balance)
        {
            throw new Exception("The transfer amount must not be greater than current account's balance.");
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