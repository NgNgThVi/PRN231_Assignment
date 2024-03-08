using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;

namespace SE160956_KeyboardShop_Assignment.Repository.Suppliers
{
    public interface ISupplierRepository
    {
        void SaveSupplier(Supplier supplier);
        Supplier GetSupplierById(string id);
        List<Supplier> GetSuppliers();
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
        List<Product> GetProducts(string supplierId);
    }
}
