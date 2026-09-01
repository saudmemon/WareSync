using WareSync.API.Models;

namespace WareSync.API.Interfaces;

public interface ICategoryService
{
    List<Category> GetAllCategories();

    Category? GetCategoryById(int id);

    void AddCategory(Category category);

    bool UpdateCategory(Category category);

    bool DeleteCategory(int id);
}