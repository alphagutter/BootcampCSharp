
using Core.Entities;
using Core.Models;
using Core.Requests.MovementModel;
using Mapster;

namespace Infrastructure.Mappings;

public class MovementMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateMovementRequest, Movement>()
            .Map(dest => dest.MovementType, src => src.MovementType)
            .Map(dest => dest.Amount, src => src.Amount);

        config.NewConfig<MovementDTO, Movement>()
            .Map(dest => dest.MovementType, src => src.MovementType)
            .Map(dest => dest.Amount, src => src.Amount);

    }
}