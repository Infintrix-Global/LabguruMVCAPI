using LabGuru.BAL;
using LabGuru.BAL.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace LabGuru.WebAPI.Models
{
    public class JwtAuthenticationManager
    {

        private readonly string key;
        
        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }
        public vm_LoginedUser GetToken(string Username, Login login)
        {

            var TokenHandler = new JwtSecurityTokenHandler();
            var TokenKey = Encoding.ASCII.GetBytes(key);
           
            var TokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Username),
                    new Claim(ClaimTypes.Role,login.RoleID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var Token = TokenHandler.CreateToken(TokenDescription);
            return new vm_LoginedUser()
            {
                Token = TokenHandler.WriteToken(Token),
                Role = login.RoleID == 1? "Doctor" : login.RoleID == 2 ? "LabAssitant" : login.RoleID == 4 ? "Process Manager":"",
                Username = login.UserName

            };
        }
        public string GetUser()
        {
            return "";
        }
        public  string SubjectId(ClaimsPrincipal user)
        {
            return user?.Claims?.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Name, StringComparison.OrdinalIgnoreCase))?.Value;
        }
    }
}
