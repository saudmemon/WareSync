using WareSync.API.Models;

namespace WareSync.API.Stores;

public class SupplierStore
{
    private readonly List<Supplier> _suppliers =
    [
        new Supplier
        {
            Id = 1,
            Name = "Logitech",
            Email = "contact@logitech.com",
            Phone = "+92-300-1234567"
        },
        new Supplier
        {
            Id = 2,
            Name = "Dell",
            Email = "sales@dell.com",
            Phone = "+92-301-9876543"
        },
        new Supplier
        {
            Id = 3,
            Name = "HP",
            Email = "support@hp.com",
            Phone = "+92-302-5555555"
        }
    ];

    public List<Supplier> GetAll() => _suppliers;

    public Supplier? GetById(int id)
        => _suppliers.FirstOrDefault(s => s.Id == id);

    public void Add(Supplier supplier)
    {
        supplier.Id = _suppliers.Max(s => s.Id) + 1;
        _suppliers.Add(supplier);
    }

    public bool Update(Supplier supplier)
    {
        var existing = GetById(supplier.Id);

        if (existing == null)
            return false;

        existing.Name = supplier.Name;
        existing.Email = supplier.Email;
        existing.Phone = supplier.Phone;

        return true;
    }

    public bool Delete(int id)
    {
        var supplier = GetById(id);

        if (supplier == null)
            return false;

        _suppliers.Remove(supplier);

        return true;
    }
}