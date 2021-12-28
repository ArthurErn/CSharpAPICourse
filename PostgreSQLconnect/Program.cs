using Microsoft.EntityFrameworkCore;
using PostgreSQLconnect;
using PostgreSQLconnect.Modules.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseNpgsql("Server=192.168.18.65;Port=5432;Database=APICsharp;User Id=postgres;Password=Kalisba987"));
var app = builder.Build();

app.MapMethods(ProductGetAll.Template, ProductGetAll.Methods, ProductGetAll.Handle);
app.MapMethods(ProductPut.Template, ProductPut.Methods, ProductPut.Handle);
app.MapMethods(ProductPost.Template, ProductPost.Methods, ProductPost.Handle);
app.MapMethods(ProductDelete.Template, ProductDelete.Methods, ProductDelete.Handle);

app.Run();
