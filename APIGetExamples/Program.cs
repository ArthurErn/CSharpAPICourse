//ATUALIZADO
//SALVANDO E RETORNANDO JSON, ARMAZENADOS NO CACHE
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//POSTAR UMA ENTIDADE E RETORNA-LA
app.MapPost("/saveproduct", (Product product) =>
{
	ProductRepo.addProduct(product);
	return "Salvo com sucesso";
});

//INFORMAÇÃO ESPECIFICADA DIRETAMENTE NA ROTA
app.MapGet("/getproduct/{code}", ([FromRoute] string code) =>
{
	var product = ProductRepo.getProduct(code);
	return product;
});


app.Run();

public static class ProductRepo
{
	public static List<Product> Products { get; set; }

	public static void addProduct(Product product)
	{
		if (Products == null)
		{
			Products = new List<Product>();
		}
		Products.Add(product);
	}

	public static Product getProduct(string code)
	{
		return Products.Last(product => product.Code == code);
	}
}

public class Product
{
	public string? Code { get; set; }
	public string? Name { get; set; }
}
