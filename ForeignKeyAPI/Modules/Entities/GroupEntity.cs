namespace ForeignKeyAPI.Modules.Entities
{
    public class Group
    {
		public Group(string nome){
			Nome = nome;
		}
		public int Id { get; set; }
		public string? Nome { get; set; }
    }
}