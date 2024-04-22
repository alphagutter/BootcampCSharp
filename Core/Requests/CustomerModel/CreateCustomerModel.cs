using Core.Constants;
using Core.Models;

namespace Core.Requests.CustomerModel;


/// <summary>
/// class where we create our customer
/// </summary>
public class CreateCustomerModel
{
    public string Name { get; set; } = string.Empty;            //required
    public string? Lastname { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;  //required
    public string? Address { get; set; }
    public string? Mail { get; set; }                           //has to be valid
    public string? Phone { get; set; }
    public string CustomerStatus { get; set; } = string.Empty;  //has to be one of the valid Statuses - required
    public DateTime? Birth { get; set; }
    public int BankId { get; set; }
}
