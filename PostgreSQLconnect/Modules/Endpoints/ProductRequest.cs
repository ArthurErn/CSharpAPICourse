namespace PostgreSQLconnect.Modules.Endpoints
{
	public class ProductRequest
	{
		public int Id { get; set; }
		public string? Nome { get; set; }
		public string? Senha { get; set; }

		// public ProductRequest(string? nome, string? senha)
		// {
		// 	Nome = nome;
		// 	Senha = senha;
		// }
	}
}