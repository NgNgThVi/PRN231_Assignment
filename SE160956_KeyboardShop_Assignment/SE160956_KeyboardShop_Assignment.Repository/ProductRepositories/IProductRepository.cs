using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;

namespace SE160956_KeyboardShop_Assignment.Repository.ProductRepositories
{
    public interface IProductRepository
    {
        void SaveProduct(Product Product);
        Product GetProductById(string id);
        List<Product> GetProducts();
        List<Product> Search(string keyword);
        void UpdateProduct(Product Product);
        void DeleteProduct(Product Product);

    }
}
