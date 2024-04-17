
using Core.Requests.ProductModel;

namespace Core.Interfaces.Repositories;

public interface IProductRepository
{
    //this task is the only that product will have, the user will not be allowed to update its request

    Task<ProductDTO> Create(CreateProductRequest request);

}
