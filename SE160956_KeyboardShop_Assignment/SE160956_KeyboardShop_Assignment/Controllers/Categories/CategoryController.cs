using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.Repository.CategoryRepositories;

namespace SE160956_KeyboardShop_Assignment.API.Controllers.Categories
{
   // [Authorize(Roles = "1")]
    [Route("api/v1/category")]
    [ApiController]
    public class CategoryController
    {
        private ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories() => _categoryRepository.GetCategories();

        [HttpPost]
        public IActionResult PostCategory(Category category)
        {
            _categoryRepository.SaveCategory(category);
            return new OkResult();
        }
    }
}
