using Microsoft.AspNetCore.Mvc;
using WareSync.API.Interfaces;
using WareSync.API.Models;

namespace WareSync.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_categoryService.GetAllCategories());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var category = _categoryService.GetCategoryById(id);

        if (category == null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        _categoryService.AddCategory(category);

        return CreatedAtAction(nameof(GetById),
            new { id = category.Id }, category);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Category category)
    {
        if (id != category.Id)
            return BadRequest();

        var updated = _categoryService.UpdateCategory(category);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleted = _categoryService.DeleteCategory(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}