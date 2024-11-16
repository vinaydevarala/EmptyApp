using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EmptyApp.CustomMiddlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ConventionalCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public ConventionalCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("Name"))
            {
                string anme = httpContext.Request.Query["Name"];
                await httpContext.Response.WriteAsync("\nHello master "+anme);
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ConventionalCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseConventionalCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConventionalCustomMiddleware>();
        }
    }
}
