﻿using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.DepositModel;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Core.Exceptions;

namespace Infrastructure.Repositories;

public class DepositRepository : IDepositRepository
{
    private readonly BootcampContext _depositContext;

    public DepositRepository(BootcampContext bootcampContext)
    {
        _depositContext = bootcampContext;
    }

    public async Task<DepositDTO> Add(CreateDepositModel model)
    {
        var deposit = model.Adapt<Deposit>();

        var account = await _depositContext.Accounts
                                      .Include(a => a.Currency)
                                      .Include(a => a.Customer)
                                      .ThenInclude(c => c.Bank)
                                      .Include(a => a.CurrentAccount)
                                      .FirstOrDefaultAsync(a => a.Id == model.AccountId);

        if (account == null) throw new NotFoundByIdException("Account", model.AccountId);


                            ///Basic Validations     
        if (account.Customer.BankId != deposit.BankId)
        {
            throw new Exception("Bank Id does not match to the customer");
        }

        if (deposit.Amount <= 0) throw new Exception("Amount must not be 0 or lower");

        if (account.CurrentAccount != null && model.Amount > account.CurrentAccount.OperationalLimit)
        {
            throw new Exception("The operation exceeds the operational limit.");
        }



        var totalAmountOperationsOATransfers = _depositContext.Transfers
                                                 .Where(t => t.OriginAccountId == account.Id &&
                                                 t.TransferredDateTime.Month == DateTime.Now.Month)
                                                 .Sum(t => t.Amount);

        //var totalAmountOperationsDATransfers = _depositContext.Transfers
        //                                 .Where(t => t.DestinationAccountId == account.Id &&
        //                                 t.TransferredDateTime.Month == DateTime.Now.Month)
        //                                 .Sum(t => t.Amount);

        var totalAmountOperationsDeposits = _depositContext.Deposits
                                                 .Where(d => d.AccountId == account.Id &&
                                                 d.DepositDateTime.Month == DateTime.Now.Month)
                                                 .Sum(d => d.Amount);

        var totalAmountOperationsExtractions = _depositContext.Extractions
                                                 .Where(e => e.AccountId == account.Id &&
                                                 e.ExtractionDateTime.Month == DateTime.Now.Month)
                                                 .Sum(e => e.Amount);

        var totalAmountOperations = totalAmountOperationsOATransfers 
            + totalAmountOperationsDeposits + totalAmountOperationsExtractions;

        if ((model.Amount + totalAmountOperations) > account.CurrentAccount!.OperationalLimit)
        {
            throw new NotFoundException("The operation exceeds the TOTAL operational limit.");
        }




        //we add the amount to the account's balance
        account.Balance = account.Balance + model.Amount;
        _depositContext.Accounts.Update(account);
        _depositContext.Deposits.Add(deposit);

        await _depositContext.SaveChangesAsync();

        var depositDTO = await _depositContext.Deposits
            .Include(d => d.Account)
            .ThenInclude(a => a.Customer)
            .ThenInclude(c => c.Bank)
            .Include(d => d.Account)
            .ThenInclude(a => a.CurrentAccount)
            .FirstOrDefaultAsync(p => p.Id == deposit.Id);

        return depositDTO.Adapt<DepositDTO>();
    }

    public async Task<DepositDTO> GetById(int id)
    {
        var deposit = await _depositContext.Deposits
            .Include(a => a.Account)
            .ThenInclude(a => a.Currency)
            .Include(a => a.Bank)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (deposit is null) throw new NotFoundByIdException("Deposit", id);

        return deposit.Adapt<DepositDTO>();
    }
}