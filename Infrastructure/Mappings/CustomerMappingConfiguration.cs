
using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests.CustomerModel;
using Mapster;

namespace Infrastructure.Mappings;

/// <summary>
/// Configuration for Customer Creation(template to create Customer and CustomerDTO)
/// </summary>
public class CustomerMappingConfiguration : IRegister

{
    public void Register(TypeAdapterConfig config)
    {
        //origin to destination(CreateCustomerModel to Customer)
        config.NewConfig<CreateCustomerModel, Customer>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Lastname, src => src.Lastname)
            .Map(dest => dest.DocumentNumber, src => src.DocumentNumber)
            .Map(dest => dest.Address, src => src.Address)
            .Map(dest => dest.Mail, src => src.Mail)
            .Map(dest => dest.Phone, src => src.Phone)
            .Map(dest => dest.CustomerStatus, src => Enum.Parse<CustomerStatus>(src.CustomerStatus))
            .Map(dest => dest.Birth, src => src.Birth)
            .Map(dest => dest.BankId, src => src.Bank.Id)
            .Map(dest => dest.Bank, src => src.Bank);

        //origin to destination(Customer to CustomerDTO)

        config.NewConfig<Customer, CustomerDTO>()

            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Lastname, src => src.Lastname)
            .Map(dest => dest.DocumentNumber, src => src.DocumentNumber)
            .Map(dest => dest.Address, src => src.Address)
            .Map(dest => dest.Mail, src => src.Mail)
            .Map(dest => dest.Phone, src => src.Phone)
            .Map(dest => dest.CustomerStatus, src => src.CustomerStatus)
            .Map(dest => dest.Birth, src => src.Birth)
            .Map(dest => dest.Bank, src => src.Bank);

    }
}
