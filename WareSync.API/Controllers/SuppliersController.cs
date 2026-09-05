using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WareSync.API.Constants;
using WareSync.API.DTOs;
using WareSync.API.Interfaces;

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
    [Authorize]
    public async Task<ActionResult<IEnumerable<SupplierDto>>> GetAll()
    {
        return Ok(await _supplierService.GetAllAsync());
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<SupplierDto>> GetById(int id)
    {
        var supplier = await _supplierService.GetByIdAsync(id);

        if (supplier == null)
            return NotFound();

        return Ok(supplier);
    }

    [HttpPost]
    [Authorize(Roles = $"{Roles.Admin},{Roles.Manager}")]
    public async Task<ActionResult<SupplierDto>> Create(CreateSupplierDto dto)
    {
        var supplier = await _supplierService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = supplier.Id }, supplier);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = $"{Roles.Admin},{Roles.Manager}")]
    public async Task<IActionResult> Update(int id, UpdateSupplierDto dto)
    {
        var updated = await _supplierService.UpdateAsync(id, dto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _supplierService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}