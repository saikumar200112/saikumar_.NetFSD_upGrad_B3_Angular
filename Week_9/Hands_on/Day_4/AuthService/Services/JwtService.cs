using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Auth_Service.Models;
using Microsoft.IdentityModel.Tokens;

namespace Auth_Service.Services
{
    public class JwtService
    {
        public string GenerateJSONWebToken(UserModel userObj)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("THIS_IS_IMPORTANT_KEY_ASKJFALKDJF57454897454"));

            SigningCredentials credentials = new SigningCredentials(securityKey,
            SecurityAlgorithms.HmacSha256);

            List<Claim> authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,Convert.ToString(userObj.UserName)),
                new Claim(ClaimTypes.Name, userObj.UserName),
                new Claim(ClaimTypes.Role, userObj.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) 
            };


            JwtSecurityToken token = new JwtSecurityToken(
                            issuer: "YourIssuer",
                            audience: "YourAudience",
                            claims: authClaims,
                            expires: DateTime.Now.AddMinutes(2),
                            signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            string tokenString = tokenHandler.WriteToken(token);    

            return tokenString;
        }
    }
}
