using DLL.Entity;
using Microsoft.IdentityModel.Tokens;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper
{
    public class JwebHelper
    {

        public static string GenreRateToken(User user, AppSettings _appSetings)
        {
            var jwtToken = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSetings.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Name,user.HoTen),
                    new Claim("Username",user.Username),
                    new Claim("UserId",user.UserID.ToString()),

                    //role
                    new Claim("TokenID",Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(300),//thời gian token tồn tại 60 phút
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)

            };
            var token = jwtToken.CreateToken(tokenDescription);

            return jwtToken.WriteToken(token);
        }
    }
}
