using Core.Models;

namespace Core.Requests.CustomerModel;
public class FilterCustomersModel
{
    /// <summary>
    /// filter where you can get the birth from a date to another
    /// </summary>
    public int? BirthYearFrom { get; set; }
    public int? BirthYearTo { get; set; }


    //it shows the full name of the customers
    public string? FullName { get; set; }

    //return the identification identity of the customers
    public string? DocumentNumber { get; set; }

    //return the mail of the customers
    public string? Mail { get; set; }

    //it shows the Bank id the customer is linked to
    public int? BankId { get; set; }
}

