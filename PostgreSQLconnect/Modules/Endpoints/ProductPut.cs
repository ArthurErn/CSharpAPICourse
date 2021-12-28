namespace PostgreSQLconnect.Modules.Endpoints
{
	public class ProductPut
	{
		public static string Template => "/product/edit";

		public static string[] Methods => new string[] { HttpMethod.Post.ToString() };

		public static Delegate Handle => Action;

		public static IResult Action(ProductRequest categoryRequest, ApplicationDBContext context)
		{
			var category = context.Product.Where(p => p.Id == categoryRequest.Id).FirstOrDefault();
			if (category is null)
				return Results.BadRequest("Nenhum usuário encontrado");
			category!.Nome = categoryRequest.Nome;
			category!.Senha = categoryRequest.Senha;
			context.SaveChanges();
			return Results.Ok("Usuário editado com sucesso!");
		}
	}
}