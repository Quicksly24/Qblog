

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class Tokenaccess:Itoken{


      public string gentoken(string username,string password){

        
        var signcredentials= new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication-")),SecurityAlgorithms.HmacSha256);

        var claims= new[]{
            new Claim(ClaimTypes.Name,username),
            new Claim(JwtRegisteredClaimNames.Email,password),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
        };

        var securitytoken = new JwtSecurityToken(
            issuer:"solo",
            audience:"post",
            // expires:_datetime.utcnow.AddMinutes(60),
            expires:DateTime.UtcNow.AddHours(10),
            claims:claims,
            signingCredentials:signcredentials

        );

        return new JwtSecurityTokenHandler().WriteToken(securitytoken);

      }

}