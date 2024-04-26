using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.CustomerModel;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
namespace Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly BootcampContext _context;

    public CustomerRepository(BootcampContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Filters where you can get things you wanted
    /// </summary>
    public async Task<List<CustomerDTO>> GetFiltered(FilterCustomersModel filter)
    {
        var query = _context.Customers
            .Include(c => c.Bank)
            .AsQueryable();


        ///filters the birth year from where they born
        if (filter.BirthYearFrom is not null)
        {
            query = query.Where(x =>
                x.Birth != null &&
                x.Birth.Value.Year >= filter.BirthYearFrom);
        }

        if (filter.BirthYearTo is not null)
        {
            query = query.Where(x =>
                x.Birth != null &&
                x.Birth.Value.Year <= filter.BirthYearTo);
        }


        //filters the name and lastname, together, and the name and lastname separately
        if (filter.FullName is not null)
        {


            query = query.Where(x =>

            x.Name != null &&
            (x.Name + " " + x.Lastname).Equals(filter.FullName) ||
            (x.Name != null && x.Name.Equals(filter.FullName)) ||
            (x.Lastname != null && x.Lastname.Equals(filter.FullName))
            
            
            );



        }


        //filters the identification identity
        if (filter.DocumentNumber is not null)
        {
            query = query.Where(x =>

            x.DocumentNumber != null &&
            x.DocumentNumber.Equals(filter.DocumentNumber)
            );
        }

        if (filter.Mail is not null)
        {
            query = query.Where(x =>
            
            x.Mail != null &&  
            x.Mail.Equals(filter.Mail) 
            );
        }

        if (filter.BankId is not null)
        {
            query = query.Where(x =>
                x.BankId.Equals(filter.BankId)
            );
        }

        var result = await query.ToListAsync();


        //verify later if it works
        return result.Select(x => x.Adapt<CustomerDTO>()).ToList();

    }


    /// <summary>
    /// Adds a customer object using the mapping configuration(search in Infrastructure/Mappings/CustomerMappingConfiguration.cs)
    /// </summary>
    public async Task<CustomerDTO> Add(CreateCustomerModel model)
    {
        //searchs for the mapping configuration
        var customertocreate = model.Adapt<Customer>();

        _context.Customers.Add(customertocreate);

        await _context.SaveChangesAsync();

        //adaptation

        var customerDTO = await _context.Customers
            .Include(c => c.Bank)
            .FirstOrDefaultAsync(a => a.Id == customertocreate.Id);


        return customerDTO.Adapt<CustomerDTO>();

    }

    /// <summary>
    /// Deletes the object without hesitation
    /// </summary>
    public async Task<bool> Delete(int id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer is null) throw new Exception("customer not found");

        _context.Customers.Remove(customer);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }


    /// <summary>
    /// returns all the customer objects
    /// </summary>
    public async Task<List<CustomerDTO>> GetAll()
    {
        var customers = await _context.Customers.ToListAsync();
        var banks = await _context.Banks.ToListAsync();


        //it adapts the mapping for the class customerDTO for a List collection
        var customersDTO = customers.Adapt<List<CustomerDTO>>();

        return customersDTO;
    }

    /// <summary>
    /// returns the customer by Id
    /// </summary>
    public async Task<CustomerDTO> GetById(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        var banks = await _context.Banks.ToListAsync();


        if (customer is null) throw new Exception("customer not found");

        //adapting customerDTO

        var customerDTO = customer.Adapt<CustomerDTO>();

        return customerDTO;

    }
    /// <summary>
    /// Updates the customer object
    /// </summary>
    public async Task<CustomerDTO> Update(UpdateCustomerModel model)
    {
        var customer = await _context.Customers.FindAsync(model.Id);

        //this search the bank object to show the name of the bank, depending of the Id
        var banks = await _context.Banks.ToListAsync();

        if (customer is null) throw new Exception("customer was not found");

        model.Adapt(customer);

        _context.Customers.Update(customer);

        await _context.SaveChangesAsync();

        //adaptation from CustomerMappingConfiguration
        var customerDTO = customer.Adapt<CustomerDTO>();

        return customerDTO;
    
    }
}