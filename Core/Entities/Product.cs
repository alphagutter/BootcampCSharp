using Core.Constants;

namespace Core.Entities;


/// <summary>
/// this class is for the product that the user will choose depending on its preference
/// </summary>
public class Product
{
    public int Id { get; set; }
    //for default, the type will be a Current Account
    public ProductType Type { get; set; } = ProductType.CurrentAccount;


    //a list for all the petitions the user requests
    public ICollection<Petition> Petitions { get; set; } = new List<Petition>();






}
