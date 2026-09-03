namespace WareSync.API.Models;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string SKU { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    // Foreign Key
    public int CategoryId { get; set; }

    public Category? Category { get; set; }

    // Foreign Key
    public int SupplierId { get; set; }

    public Supplier? Supplier { get; set; }
}