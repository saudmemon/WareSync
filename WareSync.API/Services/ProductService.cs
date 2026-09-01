using WareSync.API.Interfaces;
using WareSync.API.Models;
using WareSync.API.Stores;

namespace WareSync.API.Services;

public class ProductService : IProductService
{
    private readonly ProductStore _productStore;

    public ProductService(ProductStore productStore)
    {
        _productStore = productStore;
    }

    public List<Product> GetAllProducts()
        => _productStore.GetAll();

    public Product? GetProductById(int id)
        => _productStore.GetById(id);

    public void AddProduct(Product product)
        => _productStore.Add(product);

    public bool UpdateProduct(Product product)
        => _productStore.Update(product);

    public bool DeleteProduct(int id)
        => _productStore.Delete(id);
}