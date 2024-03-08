using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using static SE160956_KeyboardShop_Assignment.DataAccessObject.CategoriesDataAccessObject.CategoriesDAO;

namespace SE160956_KeyboardShop_Assignment.Repository.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly CategoryDAO _categoryDAO;
        public CategoryRepository()
        {
            _categoryDAO = new CategoryDAO();
        }
        public List<Category> GetCategories()
        {
            return _categoryDAO.GetCategories();
        }

        public void SaveCategory(Category category)
        {
            _categoryDAO.SaveCategory(category);
        }
    }

}
