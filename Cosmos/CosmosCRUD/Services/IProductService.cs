using CosmosCRUD.Models;

namespace CosmosCRUD.Services;

public interface IProductService
{
    Product ReadProduct(string id);
    Product CreateProduct(Product product);
    Product UpdateProduct(string productId,Product product);
    bool DeleteProduct(string id);
}