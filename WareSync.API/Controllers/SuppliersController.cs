using Microsoft.AspNetCore.Mvc;
using WareSync.API.Interfaces;
using WareSync.API.Models;

namespace WareSync.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SuppliersController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_supplierService.GetAllSuppliers());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var supplier = _supplierService.GetSupplierById(id);

        if (supplier == null)
            return NotFound();

        return Ok(supplier);
    }

    [HttpPost]
    public IActionResult Create(Supplier supplier)
    {
        _supplierService.AddSupplier(supplier);

        return CreatedAtAction(nameof(GetById),
            new { id = supplier.Id }, supplier);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Supplier supplier)
    {
        if (id != supplier.Id)
            return BadRequest();

        var updated = _supplierService.UpdateSupplier(supplier);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleted = _supplierService.DeleteSupplier(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}