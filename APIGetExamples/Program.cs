using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["Database:SqlServer"]);

var app = builder.Build();
var configuration = app.Configuration;
ProductRepo.Init(configuration);

app.MapPost("/product", (ProductRequest productRequest, ApplicationDbContext context) =>
{
	var category = context?.Category?.Where(c => c.Id == productRequest.CategoryId).First();
	var product = new Product
	{
		Code = productRequest.Code,
		Name = productRequest.Name,
		Description = productRequest.Description,
		Category = category
	};
	if (productRequest.Tags != null)
	{
		product.Tags = new List<Tag>();
		foreach (var item in productRequest.Tags)
		{
			product.Tags.Add(new Tag { Name = item });
		}
	}
	context?.Products?.Add(product);
	context?.SaveChanges();
	return Results.Created("OK", $"Usuário {product.Id} criado com sucesso!");
});

app.MapGet("/product/{id}", ([FromRoute] int id, ApplicationDbContext context) =>
{
	var product = context.Products.Include(p => p.Category).Include(p => p.Tags).Where(p => p.Id == id);
	if (product != null)
	{
		return Results.Ok(product);
	}
	return Results.NotFound();
});

app.MapPut("/product/{id}", ([FromRoute] int id, ProductRequest productRequest, ApplicationDbContext context) =>
{
	var product = context?.Products?.Include(p => p.Tags).Where(p => p.Id == id).First();
	var category = context?.Category?.Where(c => c.Id == productRequest.CategoryId).First();
	product.Code = productRequest.Code;
	product.Name = productRequest.Name;
	product.Description = productRequest.Description;
	product.Category = category;
	product.Tags = new List<Tag>();
	if (productRequest.Tags != null)
	{
		product.Tags = new List<Tag>();
		foreach (var item in productRequest.Tags)
		{
			product.Tags.Add(new Tag { Name = item });
		}
	}
	context?.SaveChanges();
	return Results.Ok("Usuário editado com sucesso!");
});

app.MapDelete("/product/{id}", ([FromRoute] int id, ApplicationDbContext context) =>
{
	var product = context.Products.Where(p => p.Id == id).First();
	context.Products.Remove(product);
	context.SaveChanges();
	return Results.Ok($"Usuário '{product?.Name}' deletado com sucesso");
});

app.MapGet("/configuration/database", (IConfiguration configuration) =>
{
	return Results.Ok(configuration["database:connection"] + ":" + configuration["database:port"]);
});

app.Run();
