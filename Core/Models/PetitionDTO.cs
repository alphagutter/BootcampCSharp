
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
    public CurrencyDTO CurrencyDTO { get; set; } = null!;
    public CustomerDTO CustomerDTO { get; set; } = null!;
    public ProductDTO ProductDTO { get; set; } = null!;
    public string? Description { get; set; }

}