namespace Core.Entities;

public class AccountTransfer
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int TransferId { get; set; }

    public Account Account { get; set; } = null!;
    public Transfer Transfer { get; set; } = null!;
}
