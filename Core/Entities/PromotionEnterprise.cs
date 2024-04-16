namespace Core.Entities;


//this is the table of the N:N between 'Promotion' and 'Enterprises' tables
public class PromotionEnterprise
{
    public int Id { get; set; }
    public int PromotionId { get; set; }
    public int EnterpriseId { get; set; }

    public Promotion Promotion { get; set; } = null!;
    public Enterprise Enterprise { get; set; } = null!;

}
