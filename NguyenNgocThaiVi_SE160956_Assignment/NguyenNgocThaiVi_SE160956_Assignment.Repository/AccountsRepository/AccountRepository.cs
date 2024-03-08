using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NguyenNgocThaiVi_SE160956_Assignment.Service.Accounts;
using NguyenNgocThaiVi_SE160956_Assignment.Service.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NguyenNgocThaiVi_SE160956_Assignment.Repository.AccountsRepository
{
    public class AccountRepository : IAccountRepository
    {
        private AccountDAO _dao;
        private IConfiguration _configuration;

        public AccountRepository(IConfiguration configuration)
        {
            _dao = new AccountDAO();
            _configuration = configuration;
        }
        public async Task<KeyboardShopResponse> CreateAdminAccount(AccountDTO request)
        {
            await _dao.Instance.CreateAdminAccount(request);
            return new KeyboardShopResponse()
            {
                Message = KeyboardShopMessage.CreateSuccess
            };
        }

        public async Task<KeyboardShopResponse> CreateCustomerAccount(AccountDTO request)
        {
            await _dao.CreateCustomerAccount(request);
            return new KeyboardShopResponse()
            {
                Message = KeyboardShopMessage.CreateSuccess
            };
        }

        public async Task<LoginModel> Login(string email, string password)
        {
            var roleClaims = new List<Claim>();

            var user = await _dao.Instance.Login(email, password);
            roleClaims.Add(new Claim("role",user.RoleName));

            List<Claim> authClaims = new List<Claim>();
            /*authClaims.Add(new Claim("email", user.Email));
            authClaims.Add(new Claim("sub", user.FullName));
            authClaims.Add(new Claim("jti", Guid.NewGuid().ToString()));
            authClaims.Add(new Claim("applicationUserId", user.ApplicationUserId.ToString()));*/
            authClaims.Add(new Claim(ClaimTypes.Role, user.RoleName));

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]!));

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: authClaims,
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JwtSettings:DurationInMinutes"]!)),
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new LoginModel
            {
                Token = accessToken,
            };
        }
    }
}
