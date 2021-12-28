using Microsoft.AspNetCore.Mvc;

namespace PostgreSQLconnect.Modules.Endpoints
{
    public class ProductGet
    {
        public static string Template => "/product/{id}";

		public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

		public static Delegate Handle => Action;

		public static IResult Action([FromRoute] int id, ApplicationDBContext context)
		{
			var response = context.Product.Where(p =>  p.Id == id).FirstOrDefault();
			if (response is null)
				return Results.Ok("Nenhum usuário encontrado");
			return Results.Ok(response);
		}
    }
}