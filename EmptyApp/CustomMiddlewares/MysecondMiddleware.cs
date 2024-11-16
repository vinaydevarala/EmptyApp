
namespace EmptyApp.CustomMiddlewares
{
    public class MysecondMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("\nMy Second MiddleWare\n");
            await next(context);
            await context.Response.WriteAsync("\nMy Second Middleware Ends\n");
        }
    }
}
