namespace Core.Entities;

public class CreditOnly
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    
    //this terms are accounted for months
    public int Terms { get; set; }

}
