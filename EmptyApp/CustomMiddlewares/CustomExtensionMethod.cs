namespace EmptyApp.CustomMiddlewares
{
    public static class CustomExtensionMethod
    {
      public static IApplicationBuilder CustomExtensionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MysecondMiddleware>();
        }
    }
}
