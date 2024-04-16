using Core.Entities;
using Core.Models;
using Core.Requests.EnterpriseModel;
using Mapster;

namespace Infrastructure.Mappings;

public class EnterpriseMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //origin to destination(CreateEnterpriseModel to Enterprise)
        config.NewConfig<CreateEnterpriseModel, Enterprise>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Address, src => src.Address)
                .Map(dest => dest.Phone, src => src.Phone)
                .Map(dest => dest.Email, src => src.Email);


        //origin to destination(Enterprise to EnterpriseDTO)
        config.NewConfig<Enterprise, EnterpriseDTO>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Address, src => src.Address)
                .Map(dest => dest.Phone, src => src.Phone)
                .Map(dest => dest.Email, src => src.Email);
    }
}