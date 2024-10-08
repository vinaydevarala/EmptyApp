var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/helloman", () => "Hello Man!");
app.MapGet("/api/new/end", (string name) => name + "hello");
app.Map("/api/vinay", newPath =>
{
    newPath.Map("/kumar", addOnPath =>
    {
        addOnPath.Run(async context =>
        {
            await context.Response.WriteAsync("HEllo This is api/vinay/kumar path");
        });
    });
    newPath.Run(async context =>
    {
        await context.Response.WriteAsync("hello this is api/vinay path");
    });
    
});
app.MapPost("/api/post", (EmptyApp.Models.Student student) =>
{
    return $"this is map post ..student id is{student.Id} and name is {student.Name}";
});

app.Run();
