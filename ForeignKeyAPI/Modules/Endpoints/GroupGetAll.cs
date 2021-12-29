namespace ForeignKeyAPI.Modules.Endpoints
{
    public class GroupGetAll
    {
        public static string Template => "/group/all";

		public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

		public static Delegate Handle => Action;

		public static IResult Action(ApplicationDBContext context)
		{
			var group = context.Group.ToList();
			var response = group.Select(p => new GroupResponse { Id = p.Id, Nome = p.Nome});
			var res = from p in context.Group.OrderBy(x=>x.Id) select p;

			if (response.ToArray().Length == 0)
				return Results.NotFound("Nenhum grupo encontrado");
			return Results.Ok(res);
		}
    }
}