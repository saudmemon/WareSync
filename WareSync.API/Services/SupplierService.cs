using WareSync.API.Interfaces;
using WareSync.API.Models;
using WareSync.API.Stores;

namespace WareSync.API.Services;

public class SupplierService : ISupplierService
{
    private readonly SupplierStore _supplierStore;

    public SupplierService(SupplierStore supplierStore)
    {
        _supplierStore = supplierStore;
    }

    public List<Supplier> GetAllSuppliers()
        => _supplierStore.GetAll();

    public Supplier? GetSupplierById(int id)
        => _supplierStore.GetById(id);

    public void AddSupplier(Supplier supplier)
        => _supplierStore.Add(supplier);

    public bool UpdateSupplier(Supplier supplier)
        => _supplierStore.Update(supplier);

    public bool DeleteSupplier(int id)
        => _supplierStore.Delete(id);
}