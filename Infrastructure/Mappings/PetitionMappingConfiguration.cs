
using Core.Entities;
using Core.Models;
using Core.Requests.PetitionModel;
using Mapster;

namespace Infrastructure.Mappings;

public class PetitionMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreatePetitionRequest, Petition>()
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.Term, src => src.Term)
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.CurrencyId, src => src.CurrencyId)
            .Map(dest => dest.CustomerId, src => src.CustomerId);
    }
}