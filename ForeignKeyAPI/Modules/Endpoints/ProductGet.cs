using Microsoft.AspNetCore.Mvc;

namespace ForeignKeyAPI.Modules.Endpoints
{
	public class ProductGet
	{
		public static string Template => "/product";

		public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

		public static Delegate Handle => Action;

		public static IResult Action([FromQuery] int id, ApplicationDBContext context)
		{
			var entity = context.Product.Where(p => p.Id == id);
			var response = entity.Select(p => new ProductResponse { Id = p.Id, Nome = p.Nome, Fabricante = p.Fabricante, Preco = p.Preco, Grupo = p.Grupo }).ToList();
			var res = from p in response.OrderBy(x => x.Id) select p;
			if (response.ToArray().Length == 0)
				return Results.NotFound($"Nenhum produto encontrado com id {id}");
			return Results.Ok(res);
		}
	}
}