using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.Models;
using SE160956_KeyboardShop_Assignment.Repository.CustomerRepositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SE160956_KeyboardShop_Assignment.Controllers.Auth
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly ICustomerRepository _accountRepository;
        private readonly IConfiguration _configuration;
        private readonly JwtSettings _jwtSettings;
        public AuthsController(ICustomerRepository accountRepository, IConfiguration configuration, IOptions<JwtSettings> jwtSettings)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            var user = _accountRepository.Login(email, password);
            if (user != null) {
                var token = GetToken(user);
                return Ok(token);
            }
            return Unauthorized("Email or password wrong, please try login!");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = _accountRepository.GetCustomerByEmail(model.Email);
            if (model.Email.Equals(_configuration["Credentials:Email"]) || userExists != null)
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User already exists!" });

            Customer user = new Customer
            {
                EmailAddress = model.Email,
                FullName = model.FullName,
                AccountPassword = model.AccountPassword,
                Role = 4
            };
            _accountRepository.SaveCustomer(user);
            return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "User created successfully!" });
        }

        private string GetToken(Customer user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var secretKey = _configuration["JwtSettings:Key"];
            if (secretKey == null) {
                return "Not Found SecretKey";
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                }),
                Expires = DateTime.Now.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
