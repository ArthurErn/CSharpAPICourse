namespace Entities
{
	public class ProductEntity
	{
		public ProductEntity(string? nome, string? senha){
			Nome = nome;
			Senha = senha;
		}
		public int Id { get; set; }
		public string? Nome { get; set; }
		public string? Senha { get; set; }
	}
}