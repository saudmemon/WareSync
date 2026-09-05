using WareSync.API.DTOs;
using WareSync.API.DTOs.Queries;

namespace WareSync.API.Interfaces;

public interface IProductService
{

    Task<IEnumerable<ProductDto>> GetAllAsync(ProductQueryParameters query);
    Task<ProductDto?> GetByIdAsync(int id);

    Task<ProductDto> CreateAsync(CreateProductDto dto);

    Task<bool> UpdateAsync(int id, UpdateProductDto dto);

    Task<bool> DeleteAsync(int id);
}