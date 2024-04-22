
using Core.Entities;
using Core.Models;
using Mapster;

namespace Infrastructure.Mappings;

public class MovementMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<Movement, MovementDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Destination, src => src.Destination)
            .Map(dest => dest.MovementType, src => src.MovementType)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransferredDateTime, src => src.TransferredDateTime)
            .Map(dest => dest.OriginAccountId, src => src.OriginAccountId)
            .Map(dest => dest.DestinationAccountId, src => src.DestinationAccountId);

    }
}