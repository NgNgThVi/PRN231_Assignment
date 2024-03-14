using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.Models;
using SE160956_KeyboardShop_Assignment.Repository.ProductRepositories;

namespace SE160956_KeyboardShop_Assignment.API.Controllers.Products
{
    [Route("api/v1/Product")]
    [ApiController]
/*    [Authorize(Roles = "1,4")]
*/    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Product>> GetProducts() => _repository.GetProducts();

        [HttpGet("Search/{keyword}")]
        public ActionResult<IEnumerable<Product>> Search(string keyword) => _repository.Search(keyword);

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(string id) => _repository.GetProductById(id);

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult PostProduct(CreateProduct postProduct)
        {
            if (_repository.GetProducts().FirstOrDefault(f => f.ProductName.ToLower().Equals(postProduct.ProductName.ToLower())) != null)
            {
                return BadRequest();
            }
            var f = new Product
            {
                ProductName = postProduct.ProductName,
                Description = postProduct.Description,
                UnitPrice = postProduct.UnitPrice,
                UnitsInStock = postProduct.UnitsInStock,
                ProductStatus = postProduct.ProductStatus,
                CategoryID = Guid.Parse(postProduct.CategoryID),
                SupplierID = Guid.Parse(postProduct.SupplierID)
            };
            _repository.SaveProduct(f);
            return NoContent();
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(string id)
        {
            var f = _repository.GetProductById(id);
            if (f == null)
            {
                return NotFound();
            }
            if (f.BookingDetails != null && f.BookingDetails.Count > 0)
            {
                f.ProductStatus = 2;
                _repository.UpdateProduct(f);
            }
            else
            {
                _repository.DeleteProduct(f);
            }
            return NoContent();
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult PutProduct(string id, CreateProduct postProduct)
        {
            var fTmp = _repository.GetProductById(id);
            if (fTmp == null)
            {
                return NotFound();
            }

            if (!fTmp.ProductName.ToLower().Equals((object)postProduct.ProductName.ToLower())
                && _repository.GetProducts().FirstOrDefault(f => f.ProductName.ToLower().Equals((object)postProduct.ProductName.ToLower())) != null)
            {
                return BadRequest();
            }
            else
            {
                fTmp.ProductName = postProduct.ProductName;
            }

            fTmp.Description = postProduct.Description;
            fTmp.UnitPrice = postProduct.UnitPrice;
            fTmp.UnitsInStock = postProduct.UnitsInStock;
            fTmp.ProductStatus = postProduct.ProductStatus;
            fTmp.CategoryID = Guid.Parse(postProduct.CategoryID);
            fTmp.SupplierID = Guid.Parse(postProduct.SupplierID);

            _repository.UpdateProduct(fTmp);
            return NoContent();
        }
    }
}
