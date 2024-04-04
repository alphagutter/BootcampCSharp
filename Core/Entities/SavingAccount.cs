using Core.Constants;

namespace Core.Entities;

public class SavingAccount
{
    public int Id { get; set; }

    public string HolderName { get; set; } = string.Empty;



    // objects
    public SavingType SavingType { get; set; } = SavingType.Insight;


    public Account Account { get; set; } = null!;


    //foreign key
    public int AccountId { get; set; }
    
    
}
