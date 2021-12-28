using Entities;
using Microsoft.AspNetCore.Mvc;

namespace PostgreSQLconnect.Modules.Endpoints
{
	public class ProductDelete
	{
		public static string Template => "/product/delete/{id}";
		public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
		public static Delegate Handle => Action;

		public static IResult Action([FromRoute] int id, ApplicationDBContext context)
		{
			var category = context.Product.Where(p => p.Id == id).FirstOrDefault();
			if (category is null)
				return Results.Ok("Usuário não encontrado");
			context.Product.Remove(category!);
			context.SaveChanges();
			return Results.Ok("Usuário " + category!.Nome + " foi removido com sucesso!");
		}
	}
}