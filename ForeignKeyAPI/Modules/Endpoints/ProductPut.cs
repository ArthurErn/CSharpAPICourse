namespace ForeignKeyAPI.Modules.Endpoints
{
    public class ProductPut
    {
        public static string Template => "/product/edit";

		public static string[] Methods => new string[] { HttpMethod.Post.ToString() };

		public static Delegate Handle => Action;

		public static IResult Action(ProductRequest pRequest, ApplicationDBContext context)
		{
			var product = context.Product.Where(p => p.Id == pRequest.Id).FirstOrDefault();
			var group = context.Group.Where(g => g.Id == pRequest.GrupoId).FirstOrDefault();
			if (product is null)
				return Results.BadRequest("Nenhum produto encontrado");
			product.Nome = pRequest.Nome;
			product.Fabricante = pRequest.Fabricante;
			product.Preco = pRequest.Preco;
			product.Grupo = group;
			context.SaveChanges();
			return Results.Ok("Produto editado com sucesso!");
		}
    }
}