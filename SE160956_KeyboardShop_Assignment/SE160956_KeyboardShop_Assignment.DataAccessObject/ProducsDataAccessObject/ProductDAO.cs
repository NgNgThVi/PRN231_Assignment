using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.BussinessObject.DbContexts;

namespace SE160956_KeyboardShop_Assignment.DataAccessObject.ProducsDataAccessObject
{
    public class ProductDAO
    {
        private static ProductDAO _instance = null;
        private readonly ApplicationDbContext _dbContext = null;

        public ProductDAO()
        {
            if (_dbContext == null)
            {
                _dbContext = new ApplicationDbContext();
            }
        }

        public static ProductDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductDAO();
                }
                return _instance;
            }
        }

        public List<BussinessObject.DataAccess.Product> GetProducts()
        {
            var listProducts = new List<BussinessObject.DataAccess.Product>();
            try
            {
                listProducts = _dbContext.Products.ToList();
                listProducts.ForEach(f =>
                {
                    f.Category = _dbContext.Categories.Find(f.CategoryID);
                    f.Supplier = _dbContext.Suppliers.Find(f.SupplierID);
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listProducts;
        }

        public List<BussinessObject.DataAccess.Product> Search(string keyword)
        {
            var listProducts = new List<BussinessObject.DataAccess.Product>();
            try
            {
                listProducts = _dbContext.Products.Where(f => f.ProductName.Contains(keyword)).ToList();
                listProducts.ForEach(f =>
                {
                    f.Category = _dbContext.Categories.Find(f.CategoryID);
                    f.Supplier = _dbContext.Suppliers.Find(f.SupplierID);
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listProducts;
        }

        public List<BussinessObject.DataAccess.Product> FindAllProductsByCategoryId(string categoryId)
        {
            var listProducts = new List<BussinessObject.DataAccess.Product>();
            try
            {
                listProducts = _dbContext.Products.Where(f => f.CategoryID == Guid.Parse(categoryId)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listProducts;
        }

        public List<BussinessObject.DataAccess.Product> FindAllProductsBySupplierId(string supplierId)
        {
            var listProducts = new List<BussinessObject.DataAccess.Product>();
            try
            {
                listProducts = _dbContext.Products.Where(f => f.SupplierID == Guid.Parse(supplierId)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listProducts;
        }

        public BussinessObject.DataAccess.Product FindProductById(string ProductId)
        {
            var Product = new BussinessObject.DataAccess.Product();
            var string1 = ProductId;
            try
            {
                Product = _dbContext.Products.SingleOrDefault(f => f.Id == Guid.Parse(ProductId));
                Product.Category = _dbContext.Categories.Find(Product.CategoryID);
                Product.Supplier = _dbContext.Suppliers.Find(Product.SupplierID);
                Product.BookingDetails = _dbContext.BookingDetail.Where(o => o.ProductId == Guid.Parse(ProductId)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Product;
        }

        public void SaveProduct(BussinessObject.DataAccess.Product Product)
        {
            try
            {
                _dbContext.Products.Add(Product);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(BussinessObject.DataAccess.Product Product)
        {
            try
            {
                _dbContext.Entry(Product).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(BussinessObject.DataAccess.Product Product)
        {
            try
            {
                var ProductToDelete = _dbContext
                    .Products
                    .SingleOrDefault(f => f.Id == Product.Id);
                _dbContext.Products.Remove(ProductToDelete);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
