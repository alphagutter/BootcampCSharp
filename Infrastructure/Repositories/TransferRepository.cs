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
                                              .Include(a => a.CurrentAccount)
                                              .FirstOrDefaultAsync(a =>
                                              (a.Id == request.DestinationAccountId));

        if (originAccount == null || destinationAccount == null)
        {
            throw new Exception("Both Accounts must exist.");
        }


        if(originAccount.Balance < request.Amount)
        {
            throw new Exception("Insufficient Balance");
        }

                                    ///Basic Validations///
        if (originAccount.Type != destinationAccount.Type)
        {
            throw new Exception("It has to be the same account type.");
        }

        if (originAccount.CurrencyId != destinationAccount.CurrencyId)
        {
            throw new Exception("It must be the same currency.");
        }

        //it validates the accounts requirements for the transaction
        var flag = false;


        //if the bank is the same, it does not need the document number and currency
        if (originAccount.Customer.BankId == destinationAccount.Customer.BankId)
        {
            flag = true;

            transfer.Bank = destinationAccount.Customer.Bank;
            transfer.Currency = destinationAccount.Currency;
        }else
        {
           flag = ValidateAccounts(originAccount, destinationAccount, request.Amount);

        }
            
            


        if (flag == true)
        {


                //we change the balances for the accounts
                originAccount.Balance = originAccount.Balance - request.Amount;
                    _transfercontext.Accounts.Update(originAccount);

                destinationAccount.Balance = destinationAccount.Balance + request.Amount;
                    _transfercontext.Accounts.Update(destinationAccount);

                
                //it adds the destination account id to the transfer
                //transfer.DestinationAccountId = destinationAccount.Id;
                    //transfer.DestinationAccount = destinationAccount;
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

        //it will check if one of the account exceeds their operation limit, counting every transactions they made
        OperationLimitValidation(originAccount, destinationAccount, amount);

        return true;
    }

    public void OperationLimitValidation(Account originAccount, Account destinationAccount, decimal amount) {

        var totalAmountOperationsOATransfers = _transfercontext.Transfers
                                                                .Where(t => t.OriginAccountId == originAccount.Id &&
                                                                t.TransferredDateTime.Month == DateTime.Now.Month)
                                                                .Sum(t => t.Amount);

        var totalAmountOperationsOADeposits = _transfercontext.Deposits
                                                             .Where(d => d.AccountId == originAccount.Id &&
                                                             d.DepositDateTime.Month == DateTime.Now.Month)
                                                             .Sum(d => d.Amount);

        var totalAmountOperationsOAExtractions = _transfercontext.Extractions
                                                              .Where(e => e.AccountId == originAccount.Id &&
                                                              e.ExtractionDateTime.Month == DateTime.Now.Month)
                                                              .Sum(e => e.Amount);

        var totalAmountOperationsOA = totalAmountOperationsOATransfers + totalAmountOperationsOADeposits + 
            totalAmountOperationsOAExtractions;

        if ((amount + totalAmountOperationsOA) > originAccount.CurrentAccount!.OperationalLimit)
        {
            throw new NotFoundException("OriginAccount exceeded the operational limit.");
        }

        var totalAmountOperationsDATransfers = _transfercontext.Transfers
                                                 .Where(t => t.DestinationAccountId == destinationAccount.Id &&
                                                 t.TransferredDateTime.Month == DateTime.Now.Month)
                                                 .Sum(t => t.Amount);

        var totalAmountOperationsDADeposits = _transfercontext.Deposits
                                                  .Where(d => d.AccountId == destinationAccount.Id &&
                                                  d.DepositDateTime.Month == DateTime.Now.Month)
                                                  .Sum(d => d.Amount);

        var totalAmountOperationsDAExtractions = _transfercontext.Extractions
                                                  .Where(e => e.AccountId == destinationAccount.Id &&
                                                  e.ExtractionDateTime.Month == DateTime.Now.Month)
                                                  .Sum(e => e.Amount);

        var totalAmountOperationsDA = totalAmountOperationsDATransfers + totalAmountOperationsDADeposits + totalAmountOperationsDAExtractions;

        if ((amount + totalAmountOperationsDA) > destinationAccount.CurrentAccount!.OperationalLimit){

            throw new NotFoundException("DestinationAccount exceeded the operational limit.");
        }

    }

}