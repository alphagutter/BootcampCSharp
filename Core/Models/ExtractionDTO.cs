
using Core.Models;

namespace Core.Entities;

public class ExtractionDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime ExtractionDateTime { get; set; }
    public AccountDTO Account { get; set; } = null!;
    public BankDTO Bank { get; set; } = null!;

}
