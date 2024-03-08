using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.DataAccessObject.ProducsDataAccessObject;
using SE160956_KeyboardShop_Assignment.DataAccessObject.SupplierDataAccessObject;

namespace SE160956_KeyboardShop_Assignment.Repository.Suppliers
{
    public class SupplierRepository : ISupplierRepository
    {
        public void SaveSupplier(Supplier supplier) => SupplierDAO.Instance.SaveSupplier(supplier);
        public Supplier GetSupplierById(string id) => SupplierDAO.Instance.FindSupplierById(id);
        public List<Supplier> GetSuppliers() => SupplierDAO.Instance.GetSuppliers();
        public void UpdateSupplier(Supplier supplier) => SupplierDAO.Instance.UpdateSupplier(supplier);
        public void DeleteSupplier(Supplier supplier) => SupplierDAO.Instance.DeleteSupplier(supplier);
        public List<Product> GetProducts(string supplierId) => ProductDAO.Instance.FindAllProductsBySupplierId(supplierId);
    }

}
