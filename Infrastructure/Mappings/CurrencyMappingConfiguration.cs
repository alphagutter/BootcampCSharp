
using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests.CurrencyModel;
using Mapster;

namespace Infrastructure.Mappings;
/// <summary>
/// Configuration for Currency Creation(template to create Currency and CurrencyDTO)
/// </summary>
public class CurrencyMappingConfiguration
{
    public void Register(TypeAdapterConfig config)
    {
        //origin to destination(CreateCurrencyModel to Currency)
        config.NewConfig<CreateCurrencyModel, Currency>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.BuyValue, src => src.BuyValue)
            .Map(dest => dest.SellValue, src => src.SellValue);


        //origin to destination(Currency to CurrencyDTO)

        config.NewConfig<Currency, CurrencyDTO>()

            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.BuyValue, src => src.BuyValue)
            .Map(dest => dest.SellValue, src => src.SellValue);  

    }

}
