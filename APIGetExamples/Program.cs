//ATUALIZADO
//SALVANDO E RETORNANDO JSON, ARMAZENADOS NO CACHE
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/product", (Product product) =>
{
	ProductRepo.addProduct(product);
	return Results.Created("OK", "Usuário criado com sucesso!");
});

app.MapGet("/product/{code}", ([FromRoute] string code) =>
{
	var product = ProductRepo.getProduct(code);
	if (product != null)
	{
		System.Console.WriteLine($"User: {product.Name}");
		return Results.Ok(product);
	}
	return Results.NotFound();
});

app.MapPut("/product", (Product product) =>
{
	var productSaved = ProductRepo.getProduct(product.Code ?? " ");
	productSaved!.Name = product.Name;
	return "Usuário editado com sucesso!";
});

app.MapDelete("/product/{code}", ([FromRoute] string code) =>
{
	var product = ProductRepo.getProduct(code);
	ProductRepo.removeProduct(product!);
	return Results.Ok($"Usuário '{product?.Name}' deletado com sucesso");
});

app.MapGet("/configuration/database", (IConfiguration configuration) =>
{
	return Results.Ok(configuration["database:connection"]);
});

app.Run();

public static class ProductRepo
{
	public static List<Product>? Products { get; set; }

	public static void addProduct(Product product)
	{
		if (Products == null)
		{
			Products = new List<Product>();
		}
		Products.Add(product);
	}

	public static Product? getProduct(string code)
	{
		return Products?.First(product => product.Code == code);
	}

	public static void removeProduct(Product product)
	{
		Products?.Remove(product);
	}
}

public class Product
{
	public string? Code { get; set; }
	public string? Name { get; set; }
}
