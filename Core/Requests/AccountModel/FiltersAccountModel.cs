
namespace Core.Requests.AccountModel;

public class FiltersAccountModel
{
    //it shows the account by number
    public string? ByNumber { get; set; }

    //it filters all the account acording to the type of account
    public string? ByType { get; set; }
    public string? ByCurrency { get; set; }
}
