
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
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.ProductId, src => src.ProductId)
            .Map(dest => dest.Description, src => src.Description);

        //origin to destination(Petition to PetitionDTO)
        config.NewConfig<Petition, PetitionDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Customer.Name)
            .Map(dest => dest.DocumentNumber, src => src.Customer.DocumentNumber)
            .Map(dest => dest.Address, src => src.Customer.Address)
            .Map(dest => dest.Mail, src => src.Customer.Mail)
            .Map(dest => dest.Phone, src => src.Customer.Phone)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.CurrencyDTO, src => src.Currency)
            .Map(dest => dest.ProductDTO, src => src.Product)
            .Map(dest => dest.CustomerDTO, src => src.Customer);
    }
}