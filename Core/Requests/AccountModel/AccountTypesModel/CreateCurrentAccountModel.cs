using Core.Constants;
using Core.Entities;
using Core.Models;

namespace Core.Requests.AccountModel.AccountTypesModel;


/// <summary>
/// class where we create our CurrentAccount
/// </summary>
public class CreateCurrentAccountModel
{
    public decimal? OperationalLimit { get; set; }
    public decimal? MonthAverage { get; set; }
    public decimal? Interest { get; set; }
    public Account Account { get; set; } = null!;
}
