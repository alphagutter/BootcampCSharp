
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

    public async Task<AccountDTO> Add(CreateAccountRequest model)
    {
        var account = model.Adapt<Account>();

        if (account.Type == AccountType.Saving)
        {
            account.SavingAccount = model.CreateSavingAccount.Adapt<SavingAccount>();
        }

        if (account.Type == AccountType.Current)
        {
            account.CurrentAccount = model.CreateCurrentAccount.Adapt<CurrentAccount>();
        }

        _context.Accounts.Add(account);

        await _context.SaveChangesAsync();

        var createdAccount = await _context.Accounts
            .Include(a => a.Currency)
            .Include(a => a.Customer)
            .Include(a => a.SavingAccount)
            .Include(a => a.CurrentAccount)
            .FirstOrDefaultAsync(a => a.Id == account.Id);

        return createdAccount.Adapt<AccountDTO>();
    }


    /// <summary>
    /// Returns the Account by Id
    /// </summary>
    public async Task<AccountDTO> GetById(int id)
    {
        var account = await _context.Accounts
            .Include(a => a.Currency)
            .Include(a => a.Customer)
            .ThenInclude(c => c.Bank)
            .Include(a => a.SavingAccount)
            .Include(a => a.CurrentAccount)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (account is null) throw new NotFoundException($"The account with id: {id} doest not exist");

        return account.Adapt<AccountDTO>();
    }



    /// <summary>
    /// Updates the Account object
    /// </summary>
    public async Task<AccountDTO> Update(UpdateAccountModel model)
    {
        var account = await _context.Accounts.FindAsync(model.Id);

        if (account is null) throw new NotFoundByIdException("Account", model.Id);
        model.Adapt(account);
        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
        //var accountDTO = account.Adapt<AccountDTO>();
        var updateAccount = await _context.Accounts
        .Include(a => a.Currency)
        .Include(a => a.Customer)
        .ThenInclude(c => c.Bank)
        .Include(a => a.SavingAccount)
        .Include(a => a.CurrentAccount)
        .FirstOrDefaultAsync(a => a.Id == account.Id);
        return updateAccount.Adapt<AccountDTO>();
    }
    public async Task<bool> Delete(int id)
    {
        var account = await _context.Accounts.FindAsync(id);

        if (account is null) throw new NotFoundByIdException("Account", id);

        account.IsDeleted = IsDeletedStatus.True;
        //account.Status = AccountStatus.Inactive;

        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
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




    //it filters all the accounts by name, by currency and by type of account
    public async Task<List<AccountDTO>> GetFiltered(FiltersAccountModel filter)
    {
        var query = _context.Accounts
                   .Include(a => a.Currency)
                   .Include(a => a.Customer)
                   .ThenInclude(a => a.Bank)
                   .Include(a => a.SavingAccount)
                   .Include(a => a.CurrentAccount)
                   //.Where(a => a.IsDeleted != IsDeletedStatus.True)
                   .AsQueryable();


        if (filter.ByCurrency is not null)
        {
            query = query.Where(x =>
                x.Currency != null &&
                x.CurrencyId == filter.ByCurrency);
        }
        if (filter.ByType.HasValue)
        {
            query = query.Where(x =>
                x.Type == filter.ByType.Value);
        }
            
        if (filter.ByNumber is not null)
        {
            query = query.Where(x =>
                x.Number != null &&
                x.Number.Equals(filter.ByNumber));
        }

        var result = await query.ToListAsync();
        var accountDTO = result.Adapt<List<AccountDTO>>();
        return accountDTO;
    }

}
