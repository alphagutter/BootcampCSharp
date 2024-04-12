using Core.Constants;
using Core.Entities;
using Core.Models;

namespace Core.Requests.AccountModel.AccountTypesModel;


/// <summary>
/// class where we create our customer
/// </summary>
public class CreateSavingAccountModel
{
    public string SavingType { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;

    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
}
