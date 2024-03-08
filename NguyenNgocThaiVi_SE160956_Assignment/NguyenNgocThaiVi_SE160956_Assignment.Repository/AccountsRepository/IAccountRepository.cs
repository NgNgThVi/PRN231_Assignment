using NguyenNgocThaiVi_SE160956_Assignment.Service.Accounts;
using NguyenNgocThaiVi_SE160956_Assignment.Service.Extensions;

namespace NguyenNgocThaiVi_SE160956_Assignment.Repository.AccountsRepository
{
    public interface IAccountRepository
    {
        public Task<KeyboardShopResponse> CreateAdminAccount(AccountDTO request);
        public Task<KeyboardShopResponse> CreateCustomerAccount(AccountDTO request);
        public Task<LoginModel> Login(string email,string password);
    }
}
