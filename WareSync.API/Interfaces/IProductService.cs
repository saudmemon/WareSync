using WareSync.API.Models;

namespace WareSync.API.Interfaces;

public interface IProductService
{
    List<Product> GetAllProducts();

    Product? GetProductById(int id);

    void AddProduct(Product product);

    bool UpdateProduct(Product product);

    bool DeleteProduct(int id);
}