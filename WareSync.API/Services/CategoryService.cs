using WareSync.API.Interfaces;
using WareSync.API.Models;
using WareSync.API.Stores;

namespace WareSync.API.Services;

public class CategoryService : ICategoryService
{
    private readonly CategoryStore _categoryStore;

    public CategoryService(CategoryStore categoryStore)
    {
        _categoryStore = categoryStore;
    }

    public List<Category> GetAllCategories()
        => _categoryStore.GetAll();

    public Category? GetCategoryById(int id)
        => _categoryStore.GetById(id);

    public void AddCategory(Category category)
        => _categoryStore.Add(category);

    public bool UpdateCategory(Category category)
        => _categoryStore.Update(category);

    public bool DeleteCategory(int id)
        => _categoryStore.Delete(id);
}