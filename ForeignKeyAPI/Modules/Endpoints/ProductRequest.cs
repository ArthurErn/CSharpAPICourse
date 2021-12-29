using ForeignKeyAPI.Modules.Entities;

namespace ForeignKeyAPI.Modules.Endpoints
{
	public class ProductRequest
	{
		public int Id { get; set; }
		public string? Nome { get; set; }
		public string? Fabricante { get; set; }
		public double Preco { get; set; }
		public int GrupoId { get; set; }
	}
}