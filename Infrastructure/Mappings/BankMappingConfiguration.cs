
using Core.Entities;
using Core.Models;
using Core.Requests.BankModel;
using Mapster;

namespace Infrastructure.Mappings;

/// <summary>
/// Configuration for Bank Creation(template to create Bank and BankDTO)
/// </summary>
public class BankMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //origin to destination(CreateBankModel to Bank)
        config.NewConfig<CreateBankModel, Bank>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Address, src => src.Address)
            .Map(dest => dest.Mail, src => src.Mail)
            .Map(dest => dest.Phone, src => src.Phone);

        //origin to destination(Bank to BankDTO)
        config.NewConfig<Bank, BankDTO>()

            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Address, src => src.Address)
            .Map(dest => dest.Mail, src => src.Mail)
            .Map(dest => dest.Phone, src => src.Phone);
    }
}
