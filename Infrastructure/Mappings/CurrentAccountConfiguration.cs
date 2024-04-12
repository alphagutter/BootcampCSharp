
using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Models.AccountTypes;
using Core.Requests.AccountModel;
using Core.Requests.AccountModel.AccountTypesModel;
using Mapster;

namespace Infrastructure.Mappings;
/// <summary>
/// Configuration for CustomerAccount Creation(template to create CurrentAccount and CurrentAccountDTO)
/// </summary>
public class CurrentAccountMappingConfiguration

{
    public void Register(TypeAdapterConfig config)
    {


        config.NewConfig<CreateCurrentAccountModel, CurrentAccount>()
            .Map(dest => dest.OperationalLimit, src => src.OperationalLimit)
            .Map(dest => dest.MonthAverage, src => src.MonthAverage)
            .Map(dest => dest.Interest, src => src.Interest)
            .Map(dest => dest.Account, src => src.Account);

        config.NewConfig<CurrentAccount, CurrentAccountDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.OperationalLimit, src => src.OperationalLimit)
            .Map(dest => dest.MonthAverage, src => src.MonthAverage)
            .Map(dest => dest.Interest, src => src.Interest)
            .Map(dest => dest.Account, src => src.Account);


    }

}