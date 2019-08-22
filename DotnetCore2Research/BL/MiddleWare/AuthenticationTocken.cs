using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Cryptography;
//https://www.blinkingcaret.com/2018/05/30/refresh-tokens-in-asp-net-core-web-api/
namespace DotnetCore2Research.BL.MiddleWare
{
    public  static class AuthenticationTocken
    {
        public static string authKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwODI1MTk4MSIsIm5hbWUiOiJtdXJhbGlrcmlzaG5hIGtvbmFua2kiLCJpYXQiOjIwNTc2NzR9.-vvXLdGTwRRTWINqIiEWkbdCEzD4Za0XQGQk5G7A0II";
        public static string GenerateToken()//IEnumerable<Claim> claims
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authKey));

            var jwt = new JwtSecurityToken(issuer: "Dotnetcore2esearch",
                audience: "Everyone",
                claims: new Claim[0], //the user's claims, for example new Claim[] { new Claim(ClaimTypes.Name, "The username"), //... 
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt); //the method is called WriteToken but returns a string
        }
        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public static SecurityToken GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authKey)),
                
                ValidateLifetime = false, // false here we are saying that we don't care about the token's expiration date
                
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return securityToken;
        }


     
    }
}
