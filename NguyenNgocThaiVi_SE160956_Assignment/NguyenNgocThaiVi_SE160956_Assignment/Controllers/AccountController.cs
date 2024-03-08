using Microsoft.AspNetCore.Mvc;
using NguyenNgocThaiVi_SE160956_Assignment.Repository.AccountsRepository;
using NguyenNgocThaiVi_SE160956_Assignment.Service.Accounts;
using NguyenNgocThaiVi_SE160956_Assignment.Service.Extensions;

namespace NguyenNgocThaiVi_SE160956_Assignment.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountRepository _repo;

        public AccountController(IAccountRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Route("admin")]
        public async Task<KeyboardShopResponse> CreateAdminAccount(AccountDTO request)
        {
            var result = await _repo.CreateAdminAccount(request);
            return result;
        }
        [HttpPost]
        [Route("customer")]
        public async Task<KeyboardShopResponse> CreateCustomerAccount(AccountDTO request)
        {
            var result = await _repo.CreateCustomerAccount(request);
            return result;
        }
        [HttpGet]
        [Route("login/{email}/{password}")]
        public async Task<LoginModel> Login(string email, string password)
        {
            var result = await _repo.Login(email, password);
            return result;
        }

    }
}
