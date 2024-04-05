using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.BankModel;
using Core.Requests.CustomerModel;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

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

        return result.Select(x => new CustomerDTO
        {
            Id = x.Id,
            Name = x.Name,
            Lastname = x.Lastname,
            DocumentNumber = x.DocumentNumber,
            Address = x.Address,
            Mail = x.Mail,
            Phone = x.Phone,
            CustomerStatus = nameof(x.CustomerStatus),
            Birth = x.Birth,
            Bank = new BankDTO
            {
                Id = x.Bank.Id,
                Name = x.Bank.Name,
                Phone = x.Bank.Phone,
                Mail = x.Bank.Mail,
                Address = x.Bank.Address
            }
        }).ToList();
    }



    //incompleto, mezclado con bank
    public async Task<BankDTO> Add(CreateCustomerModel model)
    {
        var customertocreate = new Customer
        {
            Name = model.Name,
            Lastname = model.Lastname,
            DocumentNumber = model.DocumentNumber,
            Address = model.Address,
            Mail = model.Mail,
            Phone = model.Phone,
            CustomerStatus = (CustomerStatus)Enum.Parse(typeof(CustomerStatus), model.CustomerStatus),
            Birth = model.Birth,
            BankId = model.Bank.Id,
            Bank = new Bank { }

        };

        _context.Customers.Add(customertocreate);

        await _context.SaveChangesAsync();

        var customerdto = new CustomerDTO
        {
            Id = customertocreate.Id,
            Name = customertocreate.Name,
            Lastname = customertocreate.Lastname,
            DocumentNumber = customertocreate.DocumentNumber,
            Address = customertocreate.Address,
            Mail = customertocreate.Mail,
            Phone = customertocreate.Phone,
            CustomerStatus = model.CustomerStatus,
            Birth = model.Birth,
            Bank = model.Bank
        };

        return customerdto;
    }
}