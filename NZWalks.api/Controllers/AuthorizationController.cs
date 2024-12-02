using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private string key = "pommeazertyuiopqsdfghjklmwxcvbnpommeazertyuiopqsdfghjklmwxcvbnpommeazertyuiopqsdfghjklmwxcvbn";
        // NOOIT IN PRODUCTIE
        
        [HttpPost]

        public ActionResult LogIn()
        {
            return Ok(CreateJwtToken([]));
        }

        [HttpPost]
        [Route("login_admin")]
        public ActionResult LogInWithAdminRole()
        {
            return Ok(CreateJwtToken(["admin","reader"]));
        }

        private string CreateJwtToken(List<String> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            Byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            
            //Hieronder komt de configuratie van het ticket.

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, "williamjeanray@gmail.com"));
            claims.Add(new Claim(JwtRegisteredClaimNames.FamilyName, "Jeanray"));
            claims.Add(new Claim("Hobby", "Lopen"));


            //TO DO: Rechten toevoegen

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //JWT Security

            var tokenDescriptor = new SecurityTokenDescriptor();
            tokenDescriptor.Subject = new ClaimsIdentity(claims);
            tokenDescriptor.Expires = DateTime.Now.AddHours(1);
            tokenDescriptor.Audience = "https://localhost:7207/";
            tokenDescriptor.Issuer = "https://localhost:7207/";
            tokenDescriptor.SigningCredentials = new SigningCredentials
                (
                new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256
                );

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
