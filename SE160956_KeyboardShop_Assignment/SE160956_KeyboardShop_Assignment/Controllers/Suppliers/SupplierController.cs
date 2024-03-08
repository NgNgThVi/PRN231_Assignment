using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.Repository.Suppliers;

namespace SE160956_KeyboardShop_Assignment.Controllers.Suppliers
{
    [Route("api/v1/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierRepository _repository;
        public SupplierController(ISupplierRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Supplier>> GetSuppliers() => _repository.GetSuppliers();

        [HttpPost]
        public IActionResult PostSupplier(Supplier supplier)
        {
            _repository.SaveSupplier(supplier);
            return NoContent();
        }
    }
}
