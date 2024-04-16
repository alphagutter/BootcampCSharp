using Core.Entities;
using Core.Models;
using Core.Requests.BusinessModel;
using Mapster;

namespace Infrastructure.Mappings;

public class BusinessMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //origin to destination(CreateBusinessModel to Business)
        config.NewConfig<CreateBusinessModel, Business>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Address, src => src.Address)
                .Map(dest => dest.Phone, src => src.Phone)
                .Map(dest => dest.Email, src => src.Email);


        //origin to destination(Business to BusinessDTO)
        config.NewConfig<Business, BusinessDTO>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Address, src => src.Address)
                .Map(dest => dest.Phone, src => src.Phone)
                .Map(dest => dest.Email, src => src.Email);
    }
}