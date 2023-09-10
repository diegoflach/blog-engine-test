using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using System.Dynamic;
using System.Net;

namespace BlogEngineApi.Infra.Cc.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate next;
        private const string ApiKeyName = "x-api-key";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IConfiguration configuration)
        {
            if (!context.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKey))
            {
                var statusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.StatusCode = statusCode;
                return;
            }

            if (configuration.GetSection("ApiKeys").Get<ExpandoObject[]>().All(k => !((dynamic)k).Key.Equals(extractedApiKey)))
            {
                var statusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.StatusCode = statusCode;
                return;
            }

            await next(context);
        }
    }
}