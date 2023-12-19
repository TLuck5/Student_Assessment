using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Student_Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Student_Service_Layer.Token_Services
{
    public class JwtToken_Service : I_JwtToken_Service
    {
        private readonly IConfiguration _configuration;
        public JwtToken_Service(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateToken(UsersTable user)
        {
            List<Claim> claims = new List<Claim>
            {                
                new Claim (ClaimTypes.Email, user.Email),
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:Token").Value!.PadRight(32, ' ')));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var Token = new JwtSecurityToken(
                               claims: claims,
                               expires: DateTime.Now.AddDays(1),
                               signingCredentials: creds
                               );
            var jwt = new JwtSecurityTokenHandler().WriteToken(Token);

            return jwt;
        }
    }
}
