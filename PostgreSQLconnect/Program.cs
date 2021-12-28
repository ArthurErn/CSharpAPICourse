using Microsoft.EntityFrameworkCore;
using PostgreSQLconnect;
using PostgreSQLconnect.Modules.Endpoints;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(@"Server=localhost;Database=TestingCRUD;User Id=sa;Password=@sql2021;MultipleActiveResultSets=true;Encrypt=YES;TrustServerCertificate=YES"));
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseNpgsql("Server=<YOUR_HOST>>;Port=<PORT>;Database=<DB>;User Id=postgres;Password=<YOUR_PASSWORD>>"));
var app = builder.Build();

app.MapMethods(ProductGetAll.Template, ProductGetAll.Methods, ProductGetAll.Handle);
app.MapMethods(ProductPut.Template, ProductPut.Methods, ProductPut.Handle);
app.MapMethods(ProductPost.Template, ProductPost.Methods, ProductPost.Handle);

app.Run();
