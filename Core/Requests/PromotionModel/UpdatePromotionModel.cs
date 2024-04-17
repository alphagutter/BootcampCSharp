namespace Core.Requests.PromotionModel;

public class UpdatePromotionModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public int Discount { get; set; }

    //recently added

    public List<int> EnterprisesIdsToAdd { get; set; } = new List<int>();
    public List<int> EnterprisesIdsToDelete { get; set; } = new List<int>();
}