using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using static DotnetCore2Research.BL.MiddleWare.AuthenticationTocken;
namespace DotnetCore2Research.BL.MiddleWare
{
    public class AuthenticationTockenMiddleware
    {
        private readonly RequestDelegate _next;
        private const string apiKey = "APIKEY";
        private readonly ILogger _logger;
        public AuthenticationTockenMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.CreateLogger("AuthenticationMiddleware");
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
               
                bool isValidKey = true; ;
                if (!context.Request.Headers.ContainsKey(apiKey))
                    isValidKey = false;
                if (isValidKey)
                {
                    var existingKey = context.Request.Headers[apiKey].ToString();
                    var jwtSecurityToken = GetPrincipalFromExpiredToken(existingKey);
                    if (!((System.IdentityModel.Tokens.Jwt.JwtSecurityToken)jwtSecurityToken).RawData.Equals(existingKey))
                    isValidKey = false;

                    if(jwtSecurityToken.ValidTo<DateTime.UtcNow)
                        isValidKey = false;
                }
                if (isValidKey)
                    await _next.Invoke(context);
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    await context.Response.WriteAsync("Either Header is missing or Invalid Authentication or expired authentication");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($" AuthenticationMiddleware Something went wrong: {ex}");
                throw ex;
            }
        }
    }
}
