using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.DataAccessObject.ProducsDataAccessObject;

namespace SE160956_KeyboardShop_Assignment.Repository.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        public void SaveProduct(Product Product) => ProductDAO.Instance.SaveProduct(Product);
        public Product GetProductById(string id) => ProductDAO.Instance.FindProductById(id);
        public List<Product> GetProducts() => ProductDAO.Instance.GetProducts();
        public List<Product> Search(string keyword) => ProductDAO.Instance.Search(keyword);
        public void UpdateProduct(Product Product) => ProductDAO.Instance.UpdateProduct(Product);
        public void DeleteProduct(Product Product) => ProductDAO.Instance.DeleteProduct(Product);
        //public List<BookingDetail> GetBookingDetails(int ProductId) => BookingDetailDAO.Instance.FindAllBookingDetailsByProductId(ProductId);
    }

}
