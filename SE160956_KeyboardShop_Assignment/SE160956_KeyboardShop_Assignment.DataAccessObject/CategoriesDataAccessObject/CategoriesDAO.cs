using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.BussinessObject.DbContexts;

namespace SE160956_KeyboardShop_Assignment.DataAccessObject.CategoriesDataAccessObject
{
    public class CategoriesDAO
    {
        public class CategoryDAO
        {
            private CategoryDAO _instance = null;
            private readonly ApplicationDbContext _dbContext = null;
            public CategoryDAO()
            {
                if (_dbContext == null)
                {
                    _dbContext = new ApplicationDbContext();
                }
            }

            public CategoryDAO Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new CategoryDAO();
                    }
                    return _instance;
                }
            }

            public List<Category> GetCategories()
            {
                var listCategories = new List<Category>();
                try
                {
                    listCategories = _dbContext.Categories.ToList();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return listCategories;
            }

            public void SaveCategory(Category category)
            {
                try
                {
                    _dbContext.Categories.Add(category);
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

    }
}
