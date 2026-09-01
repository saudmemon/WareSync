using WareSync.API.Models;

namespace WareSync.API.Interfaces;

public interface ISupplierService
{
    List<Supplier> GetAllSuppliers();

    Supplier? GetSupplierById(int id);

    void AddSupplier(Supplier supplier);

    bool UpdateSupplier(Supplier supplier);

    bool DeleteSupplier(int id);
}