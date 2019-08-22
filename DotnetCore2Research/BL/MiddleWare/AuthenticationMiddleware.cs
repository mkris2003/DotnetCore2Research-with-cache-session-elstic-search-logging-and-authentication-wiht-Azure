using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DotnetCore2Research.BL
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private const string authenticationKey = "65700FE1-66B6-4C3F-8530-3E3720CB8B80",apiKey="APIKEY";
        private readonly ILogger _logger;
        public AuthenticationMiddleware(RequestDelegate next, ILoggerFactory logger)
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
                 if (!context.Request.Headers[apiKey].Equals(authenticationKey))
                     isValidKey = false;

                if (isValidKey)
                    await _next.Invoke(context);
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    await context.Response.WriteAsync("Either Header is missing or Invalid Authentication");
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
