using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//METODO GET BASICO
app.MapGet("/", () => "Hello World!");

//ADICIONAR HEADERS NA ROTA GET
app.MapGet("/AddHeader", (HttpResponse response) =>
{
	response.Headers.Add("header", "Arthur ern");
	return "Olá, mundo";
});

//POSTAR UMA ENTIDADE E RETORNA-LA
app.MapPost("/saveproduct", (Product product) =>
{
	return product.Code + " - " + product.Name;
});

//PEGANDO OS DADOS POR QUERY E RETORNANDO
//EX: localhost:3001/getproduct?datainicial=26/12/2015&datafinal=21/07/2019
app.MapGet("/getproduct", ([FromQuery] string dataInicial, [FromQuery] string dataFinal) =>
{
	return dataInicial + " - " + dataFinal;
});

//INFORMAÇÃO ESPECIFICADA DIRETAMENTE NA ROTA
app.MapGet("/getproduct/{code}", ([FromRoute] string code) =>
{
	return code;
});

//RETORNA INFORMAÇÃO ADICIONADA NO HEADER
app.MapGet("/getproductheader", (HttpRequest request) =>
{
	return request.Headers["product-code"].ToString();
});


app.Run();

public class Product
{
	public string? Code { get; set; }
	public string? Name { get; set; }
}
