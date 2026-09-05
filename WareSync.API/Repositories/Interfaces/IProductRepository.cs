using WareSync.API.Models;
using WareSync.API.DTOs.Queries;

namespace WareSync.API.Repositories.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetAllAsync(ProductQueryParameters query);

    Task<Product?> GetByIdWithDetailsAsync(int id);
}