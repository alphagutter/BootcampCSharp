using Core.Interfaces.Repositories;
using Core.Models;
using Core.Exceptions;
using Infrastructure.Contexts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Requests.BankModel;
using Mapster;

namespace Infrastructure.Repositories;

public class BankRepository : IBankRepository
{
    private readonly BootcampContext _context;

    public BankRepository(BootcampContext context)
    {
        _context = context;
    }

    /// <summary>
    /// it makes a Bank object, with the Bank model, and then with that model, we create a BankDTO object
    /// </summary>
    public async Task<BankDTO> Add(CreateBankModel model)
    {
        //we adapt the structure creation with Mapping configuration
        var bankToCreate = model.Adapt<Bank>();

        _context.Banks.Add(bankToCreate);

        await _context.SaveChangesAsync();
        
        //we do the same for the dto

        var bankDTO = bankToCreate.Adapt<BankDTO>();


        return bankDTO;
    }

    /// <summary>
    /// Deletes the Bank type searching by id, returns an exception when the bank is not found
    /// </summary
    /// <returns>Boolean</returns>
    public async Task<bool> Delete(int id)
    {
        var bank = await _context.Banks.FindAsync(id);

        if (bank is null) throw new NotFoundByIdException("Bank", id);

        _context.Banks.Remove(bank);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
    /// <summary>
    /// returns all the Banks objects from the database
    /// </summary>
    /// <returns>All the Banks object</returns>
    public async Task<List<BankDTO>> GetAll()
    {
        var banks = await _context.Banks.ToListAsync();

        //it adapts the mapping for the class bankDTO for a List collection
        var banksDTO = banks.Adapt<List<BankDTO>>();

        return banksDTO;
    }
    /// <summary>
    /// Searches a bank with the provided id
    /// </summary>
    /// /// <returns>the bank with the provided Id</returns>
    public async Task<BankDTO> GetById(int id)
    {
        var bank = await _context.Banks.FindAsync(id);


        //throws an exception when the bank does not exist
        if (bank is null) throw new NotFoundByIdException("Bank", id);


        //adapting BankDTO to the mapping configuration
        var bankDTO = bank.Adapt<BankDTO>();

        return bankDTO;
    }

    /// <summary>
    /// It is not allowed to name another Bank with the same name
    /// </summary>
    public async Task<bool> NameIsAlreadyTaken(string name)
    {
        return await _context.Banks.AnyAsync(bank => bank.Name == name);
    }

    /// <summary>
    /// Updates the Bank data
    /// </summary>
    public async Task<BankDTO> Update(UpdateBankModel model)
    {
        var bank = await _context.Banks.FindAsync(model.Id);

        if (bank is null) throw new Exception("bank was not found");

        model.Adapt(bank);

        _context.Banks.Update(bank);

        await _context.SaveChangesAsync();

        //adaptation
        var bankdto = bank.Adapt<BankDTO>();

        return bankdto;
    }
}
