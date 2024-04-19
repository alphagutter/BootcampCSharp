namespace Core.Entities;

public class CurrentAccount
{
    public int Id { get; set; }
    public decimal? OperationalLimit { get; set; }
    
    //this indicates how much the limit was used, this can never be higher than the OperationalLimit
    public decimal? ActualOperationalLimit { get; set; }
    public decimal? MonthAverage { get; set; }
    public decimal? Interest { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
}