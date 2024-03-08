using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.ApplicationDbContext;
using NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models;
using NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models.Common;

namespace NguyenNgocThaiVi_SE160956_Assignment.Service.Accounts
{
    public class AccountDAO
    {
        private ApplicationDBContexts _dbContext;
        private AccountDAO _instance;
        public AccountDAO()
        {
            _dbContext = new ApplicationDBContexts();
        }
        public AccountDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountDAO();
                }
                return _instance;
            }
            set => _instance = value;
        }

        public async Task<AccountLoginResponse> Login(string email,string password)
        {
            var applicationUser = await _dbContext.ApplicationUsers.Where(x => x.Email == email && x.Password == password).SingleOrDefaultAsync();
            if(applicationUser == null)
            {
                throw new Exception("Not found");
            }
            var roleName = _dbContext.Roles.Where(x => x.Id == applicationUser.RoleId).Select(x => x.RoleName).SingleOrDefault();
            var response = new AccountLoginResponse
            {
                ApplicationUserId = applicationUser.Id,
                Email = applicationUser.Email,
                Birthday = applicationUser.Birthday,
                FullName = applicationUser.FullName,
                RoleName = roleName!
            };
            return response;
        }

        public async Task CreateAdminAccount(AccountDTO request)
        {
            var checkExisted = await _dbContext.ApplicationUsers.Where(x => string.Compare(x.Email.ToLower(), request.Email.ToLower()) == 0).FirstOrDefaultAsync();
            if (checkExisted != null)
            {
                throw new Exception();
            }
            var appUser = new ApplicationUser
            {
                Birthday = request.Birthday,
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password,
                RoleId = Guid.Parse("8F0DD22F-B780-4F87-949D-3568F3205D3B")
            };
            _dbContext.ApplicationUsers.Add(appUser);
            var admin = new Admin
            {
                ApplicationUserId = appUser.Id
            };
            _dbContext.Admins.Add(admin);

            _dbContext.SaveChanges();
        }
        public async Task CreateCustomerAccount(AccountDTO request)
        {
            var checkExisted = await _dbContext.ApplicationUsers.Where(x => string.Compare(x.Email.ToLower(), request.Email.ToLower()) == 0).FirstOrDefaultAsync();
            if (checkExisted != null)
            {
                throw new Exception();
            }
            var appUser = new ApplicationUser
            {
                Birthday = request.Birthday,
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password,
                RoleId = Guid.Parse("6EB99A73-CC38-4F04-86AB-A3923AFA0201")
            };
            _dbContext.ApplicationUsers.Add(appUser);
            var cus = new Customer
            {
                ApplicationUserId = appUser.Id
            };
            _dbContext.Customers.Add(cus);

            _dbContext.SaveChanges();
        }
    }
}
