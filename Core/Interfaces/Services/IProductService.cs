
using Core.Requests.ProductModel;

namespace Core.Interfaces.Services;

public interface IProductService
{
    Task<ProductDTO> Create(CreateProductRequest request);
}
