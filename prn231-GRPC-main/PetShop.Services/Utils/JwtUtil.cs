using Microsoft.IdentityModel.Tokens;
using PetShop.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Utils
{
    public class JwtUtil
    {
        public static string GenerateJwtToken(User user)
        {
            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
            SymmetricSecurityKey secrectKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JsonUtil.GetFromAppSettings("JwtSettings:SecretKey")));
            var credentials = new SigningCredentials(secrectKey, SecurityAlgorithms.HmacSha256Signature);
            string issuer = JsonUtil.GetFromAppSettings("JwtSettings:Issuer");
            string audience = JsonUtil.GetFromAppSettings("JwtSettings:Audience");
            List<Claim> claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub,user.Username),
                    new Claim(ClaimTypes.Role,user.Role),
                };           
            var expires = DateTime.Now.AddDays(1);
            var token = new JwtSecurityToken(issuer, null, claims, notBefore: DateTime.Now, expires, credentials);
            return jwtHandler.WriteToken(token);
        }
    }
}
