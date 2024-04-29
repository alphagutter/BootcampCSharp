
using Core.Constants;

namespace Core.Models;

public class PetitionDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string DocumentNumber { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    public CurrencyDTO Currency { get; set; } = null!;
    public CustomerDTO Customer { get; set; } = null!;
    public ProductDTO Product { get; set; } = null!;
    public string? Description { get; set; }

}