using Microsoft.AspNetCore.Mvc;

namespace ForeignKeyAPI.Modules.Endpoints
{
    public class GroupDelete
    {
        public static string Template => "/group/delete/{id}";
		public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
		public static Delegate Handle => Action;

		public static IResult Action([FromRoute] int id, ApplicationDBContext context)
		{
			var group = context.Group.Where(p => p.Id == id).FirstOrDefault();
			if (group is null)
				return Results.BadRequest("Grupo não encontrado");
			context.Group.Remove(group);
			context.SaveChanges();
			return Results.Ok("Grupo " + group.Nome + " foi removido com sucesso!");
		}
    }
}