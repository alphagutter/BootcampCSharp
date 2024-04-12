
using Core.Entities;
using Core.Models;
using Core.Interfaces.Repositories;
using Core.Requests.AccountModel;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Core.Constants;
using Core.Exceptions;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly BootcampContext _context;

    public AccountRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<AccountDTO> Add(CreateAccountModel model)
    {
        // Search for the mapping configuration
        var accountToCreate = model.Adapt<Account>();

        _context.Accounts.Add(accountToCreate);

        await _context.SaveChangesAsync();

        // Adaptation
        var accountDTO = accountToCreate.Adapt<AccountDTO>();

        return accountDTO;
    }

    /// <summary>
    /// Deletes the object without hesitation
    /// </summary>
    public async Task<bool> Delete(int id)
    {
        var account = await _context.Accounts.FindAsync(id);

        if (account is null) throw new Exception("Account not found");


        //we don't delete the account, we just change the IsDeleted variable, to be unsearcheable
        account.IsDeleted = IsDeletedStatus.True;
        account.Status = AccountStatus.Inactive;

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    /// <summary>
    /// Returns all the Account objects
    /// </summary>
    public async Task<List<AccountDTO>> GetAll()
    {
        //returns the accounts looking if the IsDeleted status is false 
        var accounts = await _context.Accounts
        .Where(account => account.IsDeleted == IsDeletedStatus.False)
        .ToListAsync();

        // Adapts the mapping for the AccountDTO class for a List collection
        var accountsDTO = accounts.Adapt<List<AccountDTO>>();

        return accountsDTO;
    }

    /// <summary>
    /// Returns the Account by Id
    /// </summary>
    public async Task<AccountDTO> GetById(int id)
    {
        var account = await _context.Accounts.FindAsync(id);

        //verifies if the account exists, or if is just logically deleted
        if (account is null || account.IsDeleted == IsDeletedStatus.True)
        {

            throw new NotFoundByIdException("Account", id);

        }

        // Adapting AccountDTO
        var accountDTO = account.Adapt<AccountDTO>();

        return accountDTO;
    }


    /// <summary>
    /// Updates the Account object
    /// </summary>
    public async Task<AccountDTO> Update(UpdateAccountModel model)
    {
        var account = await _context.Accounts.FindAsync(model.Id);


        //verifies if the account exists, or if is just logically deleted
        if (account is null || account.IsDeleted == IsDeletedStatus.True)
        {

            throw new NotFoundByIdException("Account", model.Id);

        }

        model.Adapt(account);

        _context.Accounts.Update(account);

        await _context.SaveChangesAsync();

        // Adaptation from AccountMappingConfiguration
        var accountDTO = account.Adapt<AccountDTO>();

        return accountDTO;
    }

    //it filters all the accounts by name, by currency and by type of account
    //NOT IMPLEMENTED YET
    public async Task<List<AccountDTO>> GetFiltered(FiltersAccountModel filter)
    {
        var query = _context.Accounts
            .Include(c => c.SavingAccount)
            .Include(c => c.CurrentAccount)
            .AsQueryable();

        if (filter.ByNumber is not null)
        {
            query = query.Where(x =>
                x.Number != null &&
                x.Number.Equals(filter.ByNumber)
                );
        }

        if (filter.ByType is not null)
        {
            query = query.Where(x =>
                x.Type.Equals(filter.ByType)
            );
        }

        if (filter.ByCurrency is not null)
        {
            query = query.Where(x =>
                x.Currency.Equals(filter.ByCurrency)
            );
        }

        var result = await query.ToListAsync();


        // Adaptation to a AccountDTO list mapping format
        var accountDTOs = result.Adapt<List<AccountDTO>>();

        return accountDTOs;
    }


}
