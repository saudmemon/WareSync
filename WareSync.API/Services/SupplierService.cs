using AutoMapper;
using WareSync.API.DTOs;
using WareSync.API.Interfaces;
using WareSync.API.Models;
using WareSync.API.Repositories.Interfaces;

namespace WareSync.API.Services;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _repository;
    private readonly IMapper _mapper;

    public SupplierService(ISupplierRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SupplierDto>> GetAllAsync()
    {
        var suppliers = await _repository.GetAllAsync();

        return _mapper.Map<List<SupplierDto>>(suppliers);
    }

    public async Task<SupplierDto?> GetByIdAsync(int id)
    {
        var supplier = await _repository.GetByIdAsync(id);

        if (supplier == null)
            return null;

        return _mapper.Map<SupplierDto>(supplier);
    }

    public async Task<SupplierDto> CreateAsync(CreateSupplierDto dto)
    {
        var supplier = _mapper.Map<Supplier>(dto);

        await _repository.AddAsync(supplier);
        await _repository.SaveChangesAsync();

        return _mapper.Map<SupplierDto>(supplier);
    }

    public async Task<bool> UpdateAsync(int id, UpdateSupplierDto dto)
    {
        var supplier = await _repository.GetByIdAsync(id);

        if (supplier == null)
            return false;

        _mapper.Map(dto, supplier);

        _repository.Update(supplier);

        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var supplier = await _repository.GetByIdAsync(id);

        if (supplier == null)
            return false;

        _repository.Delete(supplier);

        await _repository.SaveChangesAsync();

        return true;
    }
}