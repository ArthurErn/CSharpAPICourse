namespace ForeignKeyAPI.Modules.Endpoints
{
    public class ProductGetAll
    {
        public static string Template => "/product/all";

		public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

		public static Delegate Handle => Action;

		public static IResult Action(ApplicationDBContext context)
		{
			var product = context.Product.ToList();
			var response = product.Select(p => new ProductResponse { Id = p.Id, Nome = p.Nome, Fabricante = p.Fabricante, Preco = p.Preco, Grupo = p.Grupo});
			var res = from p in context.Product.OrderBy(x=>x.Id) select p;

			if (response.ToArray().Length == 0)
				return Results.NotFound("Nenhum produto encontrado");
			return Results.Ok(res);
		}
    }
}