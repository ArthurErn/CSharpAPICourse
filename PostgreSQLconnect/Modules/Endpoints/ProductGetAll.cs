namespace PostgreSQLconnect.Modules.Endpoints
{
	public class ProductGetAll
	{
		public static string Template => "/products";
		public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
		public static Delegate Handle => Action;

		public static IResult Action(ApplicationDBContext context)
		{
			var product = context.Product.ToList();
			var response = product.Select(p => new ProductResponse { Id = p.Id, Nome = p.Nome, Senha = p.Senha });
			return Results.Ok(response);
		}
	}
}