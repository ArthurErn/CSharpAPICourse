using Entities;

namespace PostgreSQLconnect.Modules.Endpoints
{
	public class ProductPost
	{
		public static string Template => "/product/post";
		public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
		public static Delegate Handle => Action;

		public static IResult Action(ProductRequest pRequest, ApplicationDBContext context)
		{
			var category = new ProductEntity(pRequest.Nome, pRequest.Senha)
			{
				Nome = pRequest.Nome,
				Senha = pRequest.Senha
			};
			if(pRequest.Nome == null || pRequest.Senha == null){
				if(pRequest.Senha == null)
					return Results.Ok("Por favor insira uma senha");
				if(pRequest.Nome == null)
					return Results.Ok("Por favor insira um usuário");
				return Results.Ok("Erro ao criar usuário.");
			}
			var productList = context.Product.Where(p => p.Nome == pRequest.Nome).FirstOrDefault();
			if(productList is not null)
				return Results.Ok("Usuário já existente");
			context.Product.Add(category);
			context.SaveChanges();
			return Results.Ok("Usuário " + category.Nome + " foi criado com sucesso!");
		}
	}
}