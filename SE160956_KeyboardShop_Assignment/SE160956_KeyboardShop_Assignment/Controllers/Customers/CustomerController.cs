using Microsoft.AspNetCore.Mvc;
using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.Models;
using SE160956_KeyboardShop_Assignment.Repository.CustomerRepositories;

namespace SE160956_KeyboardShop_Assignment.API.Controllers.Customers
{
    [Route("api/v1/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers() => _customerRepository.GetCustomers();

        [HttpGet("search/{keyword}")]
        public ActionResult<IEnumerable<Customer>> Search(string keyword) => _customerRepository.Search(keyword);

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(string id) => _customerRepository.GetCustomerById(id);

        [HttpGet("email/{email}")]
        public ActionResult<Customer> GetCustomerByEmail(string email) => _customerRepository.GetCustomerByEmail(email);

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(string id)
        {
            var c = _customerRepository.GetCustomerById(id);
            if (c == null)
            {
                return NotFound();
            }
            _customerRepository.DeleteCustomer(c);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer(string id, EditCustomer editCustomer)
        {
            var cTmp = _customerRepository.GetCustomerById(id);
            if (cTmp == null)
            {
                return NotFound();
            }

            cTmp.FullName = editCustomer.CustomerName;

            if (editCustomer.AccountPassword != null && cTmp.AccountPassword != editCustomer.AccountPassword)
            {
                cTmp.AccountPassword = editCustomer.AccountPassword;
            }

            _customerRepository.UpdateCustomer(cTmp);
            return NoContent();
        }
    }
}
