using WareSync.API.Models;

namespace WareSync.API.Stores;

public class CategoryStore
{
    private readonly List<Category> _categories =
    [
        new Category
        {
            Id = 1,
            Name = "Electronics"
        },
        new Category
        {
            Id = 2,
            Name = "Accessories"
        },
        new Category
        {
            Id = 3,
            Name = "Furniture"
        }
    ];

    public List<Category> GetAll() => _categories;

    public Category? GetById(int id)
        => _categories.FirstOrDefault(c => c.Id == id);

    public void Add(Category category)
    {
        category.Id = _categories.Max(c => c.Id) + 1;
        _categories.Add(category);
    }

    public bool Update(Category category)
    {
        var existing = GetById(category.Id);

        if (existing == null)
            return false;

        existing.Name = category.Name;

        return true;
    }

    public bool Delete(int id)
    {
        var category = GetById(id);

        if (category == null)
            return false;

        _categories.Remove(category);

        return true;
    }
}