using EmptyApp.CustomConstraints;
using EmptyApp.CustomMiddlewares;
using EmptyApp.CustomModelBinders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//For Model Binder Provider
builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new BinderProvider());
});
builder.Services.AddControllersWithViews();

//it is for log file in our project
Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.File("log/log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
//Log.Logger = new LoggerConfiguration().MinimumLevel.Warning().WriteTo.File("log/log.txt", rollingInterval: RollingInterval.Minute).CreateBootstrapLogger();
builder.Host.UseSerilog();

builder.Services.AddScoped<MyFirstMiddleware>();
builder.Services.AddScoped<MysecondMiddleware>();


builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("cstm", typeof(MyRouteConstraint));
});

var app = builder.Build();
//app.Map("/", (context) => context.Response.WriteAsync("\nHEllo"));
//app.UseRouting();

//app.MapGet("/helloman", () => "Hello Man!");
//app.MapGet("/api/new/end/{id:int}", (string name) => name + "hello");
//app.Map("/api/vinay", newPath =>
//{
//    newPath.Map("/kumar", addOnPath =>
//    {
//        addOnPath.Run(async context =>
//        {
//            await context.Response.WriteAsync("HEllo This is api/vinay/kumar path");
//        });
//    });
//    newPath.Run(async context =>
//    {
//        await context.Response.WriteAsync("hello this is api/vinay path");
//    });

//});
//app.MapPost("/api/post", (EmptyApp.Models.Student student) =>
//{
//    return $"this is map post ..student id is{student.Id} and name is {student.Name}";
//});
app.MapControllers();
app.UseStaticFiles();
//app.Use(async (context, next) =>
//{
//    Endpoint? endpoint = context.GetEndpoint();
//    if (endpoint != null)
//    {
//        await context.Response.WriteAsync($"Endpoint::{endpoint.DisplayName}");
//    }
//    await next(context);
//});


//app.CustomExtensionMiddleware();
//app.UseMiddleware<MyFirstMiddleware>();
//app.UseConventionalCustomMiddleware();
//app.UseStaticFiles();

//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//   await context.Response.WriteAsync("\n Middleware-1");
//    next(context);

//});
//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/myend", async context =>
//    {
//        await context.Response.WriteAsync("\n new endpoint by routing");
//    });
//    endpoints.Map("/a", async context =>
//    {
//        await context.Response.WriteAsync($"\ndefault page");
//    });
//    endpoints.Map("/download/{filename:cstm}.{extension:length(3,3)?}", async context =>//route constraints
//    {
//        string? file = Convert.ToString(context.Request.RouteValues["filename"]);
//        string? ext = Convert.ToString(context.Request.RouteValues["extension"]);
//        await context.Response.WriteAsync($"\nFilename--{file},Extension::{ext}");
//    });
//});
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("\nthe path is " + context.Request.Path);
//});
app.Run();

