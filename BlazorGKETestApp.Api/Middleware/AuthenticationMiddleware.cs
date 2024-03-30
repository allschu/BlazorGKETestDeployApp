using System.Net;

namespace BlazorGKETestApp.Api;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public AuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _configuration = configuration;
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        if (string.IsNullOrWhiteSpace(context.Request.Headers["X-API-KEY"]))
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return;
        }
        string? userApiKey = context.Request.Headers["X-API-KEY"];
        if (_configuration["ApiKey"] != userApiKey)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return;
        }
        await _next(context);
    }
}
