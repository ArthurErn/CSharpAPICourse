using ForeignKeyAPI.Modules;
using ForeignKeyAPI.Modules.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseNpgsql(builder.Configuration["ConnectionString:Default"]));
var app = builder.Build();

app.MapGet("/", () => "Teste!");

app.MapMethods(GroupGetAll.Template, GroupGetAll.Methods, GroupGetAll.Handle);
app.MapMethods(GroupPost.Template, GroupPost.Methods, GroupPost.Handle);
app.MapMethods(ProductGetAll.Template, ProductGetAll.Methods, ProductGetAll.Handle);
app.MapMethods(ProductPost.Template, ProductPost.Methods, ProductPost.Handle);
app.MapMethods(ProductGet.Template, ProductGet.Methods, ProductGet.Handle);


app.Run();
