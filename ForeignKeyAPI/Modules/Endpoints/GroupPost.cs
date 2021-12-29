using ForeignKeyAPI.Modules.Entities;

namespace ForeignKeyAPI.Modules.Endpoints
{
	public class GroupPost
	{
		public static string Template => "/group/post";
		public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
		public static Delegate Handle => Action;

		public static IResult Action(GroupRequest gRequest, ApplicationDBContext context)
		{
			var category = new Group()
			{
				Nome = gRequest.Nome
			};
			if (gRequest.Nome == "")
			{
				return Results.BadRequest("Por favor insira um nome");
			}
			var groupList = context.Group.Where(g => g.Nome == gRequest.Nome).FirstOrDefault();
			if (groupList is not null)
				return Results.BadRequest("Grupo já existente");
			context.Group.AddRange(category);
			context.SaveChanges();
			return Results.Created("", "Grupo " + category.Nome + " criado com sucesso!");
		}
	}
}