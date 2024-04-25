
using Core.Entities;
using Core.Models;
using Core.Requests.BankModel;
using Core.Requests.ExtractionModel;
using Mapster;

namespace Infrastructure.Mappings;

/// <summary>
/// Configuration for Extraction Request(template to request Extraction and ExtractionDTO)
/// </summary>
public class ExtractionMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //origin to destination(CreateExtractionRequest to Extraction)
        config.NewConfig<CreateExtractionRequest, Extraction>()
           .Map(dest => dest.BankId, src => src.BankId)
           .Map(dest => dest.Amount, src => src.Amount)
           .Map(dest => dest.ExtractionDateTime, src => DateTime.UtcNow);


        //origin to destination(Extraction to ExtractionDTO)
        config.NewConfig<Extraction, ExtractionDTO>()
           .Map(dest => dest.Id, src => src.Id)
           .Map(dest => dest.Bank, src => src.Bank)
           .Map(dest => dest.Amount, src => src.Amount)
           .Map(dest => dest.ExtractionDateTime, src => src.ExtractionDateTime);
    }
}