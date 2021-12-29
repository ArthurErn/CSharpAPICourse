using Microsoft.AspNetCore.Mvc;

namespace ForeignKeyAPI.Modules.Endpoints
{
    public class ProductDelete
    {
		public static string Template => "/product/delete/{id}";
		public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
		public static Delegate Handle => Action;

		public static IResult Action([FromRoute] int id, ApplicationDBContext context)
		{
			var product = context.Product.Where(p => p.Id == id).FirstOrDefault();
			if (product is null)
				return Results.BadRequest("Produto não encontrado");
			context.Product.Remove(product);
			context.SaveChanges();
			return Results.Ok("Produto " + product.Nome + " foi removido com sucesso!");
		}
    }
}