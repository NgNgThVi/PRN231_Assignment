using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.BussinessObject.DbContexts;

namespace SE160956_KeyboardShop_Assignment.DataAccessObject.SupplierDataAccessObject
{
    public class SupplierDAO
    {
        private static SupplierDAO _instance = null;
        private readonly ApplicationDbContext _dbContext = null;

        public SupplierDAO()
        {
            if (_dbContext == null)
            {
                _dbContext = new ApplicationDbContext();
            }
        }

        public static SupplierDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SupplierDAO();
                }
                return _instance;
            }
        }
        public List<Supplier> GetSuppliers()
        {
            var listSuppliers = new List<Supplier>();
            try
            {
                listSuppliers = _dbContext.Suppliers.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listSuppliers;
        }

        public Supplier FindSupplierById(string supplierId)
        {
            var supplier = new Supplier();
            try
            {
                supplier = _dbContext.Suppliers.SingleOrDefault(s => s.Id == Guid.Parse(supplierId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return supplier;
        }

        public void SaveSupplier(Supplier supplier)
        {
            try
            {
                _dbContext.Suppliers.Add(supplier);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateSupplier(Supplier supplier)
        {
            try
            {
                _dbContext.Entry(supplier).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteSupplier(Supplier supplier)
        {
            try
            {
                var supplierToDelete = _dbContext
                    .Suppliers
                    .SingleOrDefault(s => s.Id == supplier.Id);
                _dbContext.Suppliers.Remove(supplierToDelete);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
