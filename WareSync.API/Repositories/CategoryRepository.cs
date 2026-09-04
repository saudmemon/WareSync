using WareSync.API.Data;
using WareSync.API.Models;
using WareSync.API.Repositories.Interfaces;

namespace WareSync.API.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}