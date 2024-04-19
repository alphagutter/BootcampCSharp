using Core.Constants;

namespace Core.Models;

public class ProductDTO
{
    public int Id { get; set; }
    public ProductType Type { get; set; } = ProductType.CurrentAccount;
}