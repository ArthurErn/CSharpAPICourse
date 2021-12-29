using ForeignKeyAPI.Modules.Entities;

namespace ForeignKeyAPI.Modules.Endpoints
{
	public class ProductPost
	{
		public static string Template => "/product/post";
		public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
		public static Delegate Handle => Action;

		public static IResult Action(ProductRequest pRequest, ApplicationDBContext context)
		{
			var group = context.Group.Where(g => g.Id == pRequest.GrupoId).FirstOrDefault();
			if (group is null) return Results.BadRequest("Falha ao cadastrar produto ( grupo inexistente )");
			var product = new Product
			{
				Nome = pRequest.Nome,
				Fabricante = pRequest.Fabricante,
				Preco = pRequest.Preco,
				Grupo = group
			};
			context.Product.Add(product);
			context.SaveChanges();
			return Results.Created("OK", $"Produto {product.Nome} criado com sucesso!");
		}
	}
}