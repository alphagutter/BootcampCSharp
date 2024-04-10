
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.CreditCardModel;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories;

public class CreditCardRepository : ICreditCardRepository
{
    private readonly BootcampContext _context;

    public CreditCardRepository(BootcampContext context)
    {
        _context = context;
    }


    /// <summary>
    /// Adds a credit card object using the mapping configuration(search in Infrastructure/Mappings/CreditCardMappingConfiguration.cs)
    /// </summary>
    public async Task<List<CreditCardDTO>> GetFiltered(FiltersCreditCardModel filter)
    {
        var query = _context.CreditCards
            .Include(c => c.Customer)
            .Include(c => c.Currency)
            .AsQueryable();


        //-by designation
        if (filter.ByDesignation != null) {

            //he will use the first letter of the filter, to search it into all the designations
            var searchWWord = filter.ByDesignation.Trim().ToLower();
            query = query.Where(x =>

            //he will search if it matches 
            x.Designation.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Any(word => word.StartsWith(searchWWord))
            );
        }
        //-by customer
        if (filter.ByCustomerName != null)
        {

            //he will use the first letter of the filter, to search it into all the designations
            var searchWWord = filter.ByCustomerName.Trim().ToLower();
            query = query.Where(x =>

            //he will search if it matches 
            x.Customer.Name.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Any(word => word.StartsWith(searchWWord))
            );
        }


        var result = await query.ToListAsync();

        return result.Adapt<List<CreditCardDTO>>();

    }

    public async Task<CreditCardDTO> Add(CreateCreditCardModel model)
    {
        var creditCardToAdd = model.Adapt<CreditCard>();

        if (creditCardToAdd.Currency == null) throw new NotFoundByIdException("Currency", creditCardToAdd.CurrencyId);
        if (creditCardToAdd.Customer == null) throw new NotFoundByIdException("Customer", creditCardToAdd.CustomerId);

        _context.CreditCards.Add(creditCardToAdd);
        await _context.SaveChangesAsync();

        var addedCreditCardDTO = creditCardToAdd.Adapt<CreditCardDTO>();

        return addedCreditCardDTO;
    }



    /// <summary>
    /// returns the Credit Card by Id
    /// </summary>
    public async Task<CreditCardDTO> GetById(int id)
    {
        var creditcard = await _context.CreditCards.FindAsync(id);

        if (creditcard is null) throw new NotFoundByIdException("Credit Card", id);

        //adapting creditcardDTO

        var creditcardDTO = creditcard.Adapt<CreditCardDTO>();

        return creditcardDTO;

    }
    /// <summary>
    /// Updates the credit card object
    /// </summary>
    public async Task<CreditCardDTO> Update(UpdateCreditCardModel model)
    {
        var creditcard = await _context.CreditCards.FindAsync(model.Id);

        if (creditcard.Currency == null) throw new NotFoundByIdException("Currency", creditcard.CurrencyId);
        if (creditcard.Customer == null) throw new NotFoundByIdException("Customer", creditcard.CustomerId);

        if (creditcard is null) throw new NotFoundByIdException("Credit Card", model.Id);

        model.Adapt(creditcard);

        _context.CreditCards.Update(creditcard);

        await _context.SaveChangesAsync();

        //adaptation from CustomerMappingConfiguration
        var creditcardDTO = creditcard.Adapt<CreditCardDTO>();

        return creditcardDTO;

    }

    /// <summary>
    /// Deletes the object without hesitation
    /// </summary>
    public async Task<bool> Delete(int id)
    {
        var creditcard = await _context.CreditCards.FindAsync(id);

        if (creditcard is null) throw new NotFoundByIdException("Credit Cards", id);

        _context.CreditCards.Remove(creditcard);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    /// <summary>
    /// returns all the credit card objects
    /// </summary>
    public async Task<List<CreditCardDTO>> GetAll()
    {
        var creditcards = await _context.CreditCards.ToListAsync();

        //it adapts the mapping for the CreditCardDTO for a list collection
        var creditcardDTO = creditcards.Adapt<List<CreditCardDTO>>();

        return creditcardDTO;
    }


}
