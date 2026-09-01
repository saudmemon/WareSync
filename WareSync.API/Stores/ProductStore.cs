using System.Linq;
using WareSync.API.Models;

namespace WareSync.API.Stores;

public class ProductStore
{
    private readonly List<Product> _products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Mechanical Keyboard",
            Description = "RGB Mechanical Keyboard",
            SKU = "KEY-001",
            Price = 8500,
            Quantity = 25,
            Category = "Accessories",
            Supplier = "Logitech"
        },
        new Product
        {
            Id = 2,
            Name = "Wireless Mouse",
            Description = "Bluetooth Mouse",
            SKU = "MOU-001",
            Price = 3500,
            Quantity = 40,
            Category = "Accessories",
            Supplier = "Logitech"
        }
    };

    public List<Product> GetAll() => _products;

    public Product? GetById(int id)
        => _products.FirstOrDefault(p => p.Id == id);

    public void Add(Product product)
    {
        product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
        _products.Add(product);
    }

    public bool Update(Product product)
    {
        var existing = GetById(product.Id);

        if (existing == null)
            return false;

        existing.Name = product.Name;
        existing.Description = product.Description;
        existing.SKU = product.SKU;
        existing.Price = product.Price;
        existing.Quantity = product.Quantity;
        existing.Category = product.Category;
        existing.Supplier = product.Supplier;

        return true;
    }

    public bool Delete(int id)
    {
        var product = GetById(id);

        if (product == null)
            return false;

        _products.Remove(product);

        return true;
    }
}