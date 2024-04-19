
using Core.Entities;
using Core.Models;
using Core.Requests.PetitionModel;
using Mapster;

namespace Infrastructure.Mappings;

public class PetitionMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //origin to destination(CreatePetitionRequest to Petition)
        config.NewConfig<CreatePetitionRequest, Petition>()
            .Map(dest => dest.CurrencyId, src => src.CurrencyId)
            .Map(dest => dest.ProductId, src => src.ProductId)
            .Map(dest => dest.CustomerId, src => src.CustomerId);

        //origin to destination(Petition to PetitionDTO)
        config.NewConfig<Petition, PetitionDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Currency, src => src.Currency)
            .Map(dest => dest.ProductType, src => src.Product.Type)
            .Map(dest => dest.Customer, src => src.Customer);
    }
}