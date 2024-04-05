using Core.Models;

namespace Core.Requests.CustomerModel;

public class UpdateCustomerModel
{
    public int Id { get; set; }  
    public string? Name { get; set; }
    public string? Lastname { get; set; }
    //document cannot be null
    public string DocumentNumber { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    //customer status cannot be null
    public string CustomerStatus { get; set; } = string.Empty;
    public DateTime? Birth { get; set; }
    public BankDTO Bank { get; set; } = null!;
}
