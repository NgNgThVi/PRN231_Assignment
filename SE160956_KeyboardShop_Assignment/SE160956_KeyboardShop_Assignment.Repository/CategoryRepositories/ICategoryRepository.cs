using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;

namespace SE160956_KeyboardShop_Assignment.Repository.CategoryRepositories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        void SaveCategory(Category category);
    }
}
