namespace PostgreSQLconnect.Modules.Endpoints
{
	public class ProductPut
	{
		public static string Template => "/product";
		public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
		public static Delegate Handle => Action;

		public static IResult Action(ProductRequest categoryRequest, ApplicationDBContext context)
		{
			var category = context.Product.Where(p => p.Id == categoryRequest.Id).FirstOrDefault();
			category!.Nome = categoryRequest.Nome;
			category!.Senha = categoryRequest.Senha;
			context.SaveChanges();
			return Results.Ok("Usuário editado com sucesso!");
		}
	}
}