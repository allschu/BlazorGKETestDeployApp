using System.Net;

namespace BlazorGKETestApp.Api.Authentication
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private const string ApiKey = "X-API-KEY";

        public ApiKeyAuthMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(ApiKey, out var apiKeyVal))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(ApiKey);
            if (!apiKey.Equals(apiKeyVal))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            await _requestDelegate(context);
        }
    }
}