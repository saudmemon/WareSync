using Microsoft.EntityFrameworkCore;
using WareSync.API.Data;
using WareSync.API.DTOs.Queries;
using WareSync.API.Models;
using WareSync.API.Repositories.Interfaces;

namespace WareSync.API.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetAllAsync(ProductQueryParameters query)
    {
        IQueryable<Product> products = _context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier);

        // Search
        if (!string.IsNullOrWhiteSpace(query.Keyword))
        {
            products = products.Where(p =>
                p.Name.Contains(query.Keyword) ||
                p.Description.Contains(query.Keyword) ||
                p.SKU.Contains(query.Keyword));
        }

        // Filter
        if (query.CategoryId.HasValue)
            products = products.Where(p => p.CategoryId == query.CategoryId);

        if (query.SupplierId.HasValue)
            products = products.Where(p => p.SupplierId == query.SupplierId);

        // Sorting
        products = query.SortBy?.ToLower() switch
        {
            "price" => query.Descending
                ? products.OrderByDescending(p => p.Price)
                : products.OrderBy(p => p.Price),

            "quantity" => query.Descending
                ? products.OrderByDescending(p => p.Quantity)
                : products.OrderBy(p => p.Quantity),

            _ => query.Descending
                ? products.OrderByDescending(p => p.Name)
                : products.OrderBy(p => p.Name)
        };

        // Pagination
        products = products
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize);

        return await products.ToListAsync();
    }

    public async Task<Product?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}