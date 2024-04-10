using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.BankModel;
using Core.Requests.CustomerModel;
using Core.Requests.CurrencyModel;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Mappings;
using Core.Exceptions;

namespace Infrastructure.Repositories;

public class CurrencyRepository : ICurrencyRepository
{
    private readonly BootcampContext _context;

    public CurrencyRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<List<CurrencyDTO>> GetFiltered(FiltersCurrencyModel filter)
    {
        var query = _context.Currencies
            .AsQueryable();

        //converts the currency name into a lowercase for an easy search with the data that the user provides
        if (filter.CurrencyName != null) {

            string normalizedFilterName = filter.CurrencyName.ToLower();
            query = query.Where(x  => x.Name.ToLower().Equals(normalizedFilterName));
        }

        var result = await query.ToListAsync();
        var currencyDTO = result.Adapt<List<CurrencyDTO>>();
        return currencyDTO;
    
    }

        /// <summary>
        /// Adds a currency object using the mapping configuration(search in Infrastructure/Mappings/CurrencyMappingConfiguration.cs)
        /// </summary>
        public async Task<CurrencyDTO> Add(CreateCurrencyModel model)
    {
        //searchs for the mapping configuration
        var currencytocreate = model.Adapt<Currency>();

        _context.Currencies.Add(currencytocreate);

        await _context.SaveChangesAsync();

        //adaptation to mapping configuration for the DTO

        var currencyDTO = currencytocreate.Adapt<CurrencyDTO>();


        return currencyDTO;
    }


    /// <summary>
    /// Deletes the object without hesitation
    /// </summary>
    public async Task<bool> Delete(int id)
    {
        var currency = await _context.Currencies.FindAsync(id);

        if (currency is null) throw new NotFoundByIdException("Currency", id);

        _context.Currencies.Remove(currency);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }


    /// <summary>
    /// returns all the currency objects
    /// </summary>
    public async Task<List<CurrencyDTO>> GetAll()
    {
        var currencys = await _context.Currencies.ToListAsync();


        //it adapts the mapping for the class currencyDTO for a List collection
        var currencyDTO = currencys.Adapt<List<CurrencyDTO>>();

        return currencyDTO;
    }

    /// <summary>
    /// returns the currency by Id
    /// </summary>
    public async Task<CurrencyDTO> GetById(int id)
    {
        var currency = await _context.Currencies.FindAsync(id);

        if (currency is null) throw new NotFoundByIdException("Currency", id);

        //adapting customerDTO

        var currencyDTO = currency.Adapt<CurrencyDTO>();

        return currencyDTO;

    }
    /// <summary>
    /// Updates the currency object
    /// </summary>
    public async Task<CurrencyDTO> Update(UpdateCurrencyModel model)
    {
        var currency = await _context.Currencies.FindAsync(model.Id);


        if (currency is null) throw new NotFoundByIdException("Currency", model.Id);

        model.Adapt(currency);

        _context.Currencies.Update(currency);

        await _context.SaveChangesAsync();

        //adaptation from CustomerMappingConfiguration
        var currencyDTO = currency.Adapt<CurrencyDTO>();

        return currencyDTO;

    }
}
