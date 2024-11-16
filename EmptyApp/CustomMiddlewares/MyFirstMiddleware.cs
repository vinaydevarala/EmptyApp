
namespace EmptyApp.CustomMiddlewares
{
    public class MyFirstMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("this is my My First Custom Middleware");
            await next(context);
            //after execution 
        }
    }
}
