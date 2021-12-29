using ForeignKeyAPI.Modules;
using ForeignKeyAPI.Modules.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseNpgsql(builder.Configuration["ConnectionString:Default"]));
var app = builder.Build();

app.MapGet("/", () => "Bem vindo a minha API teste!");

app.MapMethods(GroupGetAll.Template, GroupGetAll.Methods, GroupGetAll.Handle);
app.MapMethods(GroupPost.Template, GroupPost.Methods, GroupPost.Handle);
app.MapMethods(GroupDelete.Template, GroupDelete.Methods, GroupDelete.Handle);

app.MapMethods(ProductGetAll.Template, ProductGetAll.Methods, ProductGetAll.Handle);
app.MapMethods(ProductPost.Template, ProductPost.Methods, ProductPost.Handle);
app.MapMethods(ProductGet.Template, ProductGet.Methods, ProductGet.Handle);
app.MapMethods(ProductPut.Template, ProductPut.Methods, ProductPut.Handle);
app.MapMethods(ProductDelete.Template, ProductDelete.Methods, ProductDelete.Handle);


app.Run();
