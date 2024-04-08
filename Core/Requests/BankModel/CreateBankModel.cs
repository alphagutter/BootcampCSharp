namespace Core.Requests.BankModel;

public class CreateBankModel
{
    public string? Name { get; set; }               //no less than 5 letters
    public string? Phone { get; set; }              //required
    public string? Mail { get; set; }               //has to be a valid mail
    public string? Address { get; set; }
}
