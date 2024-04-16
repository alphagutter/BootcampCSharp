using Core.Entities;
using Core.Models;
using Core.Requests.PromotionModel;
using Mapster;

namespace Infrastructure.Mappings;


public class PromotionMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // origin to destination (CreatePromotionModel to Promotion)
        config.NewConfig<CreatePromotionModel, Promotion>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Start, src => src.Start)
            .Map(dest => dest.End, src => src.End)
            .Map(dest => dest.Discount, src => src.Discount);

        // origin to destination (Promotion to PromotionDTO)
        config.NewConfig<Promotion, PromotionDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Start, src => src.Start)
            .Map(dest => dest.End, src => src.End)
            .Map(dest => dest.Discount, src => src.Discount);
    }

}