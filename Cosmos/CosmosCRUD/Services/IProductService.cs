using CosmosCRUD.Models;

namespace CosmosCRUD.Services;

public interface IProductService
{
    Product? ReadProduct(string id);
    Product? CreateProduct(Product product);
    Product? UpdateProduct(Product product);
    bool DeleteProduct(string id);
}