using ForeignKeyAPI.Modules.Entities;

namespace ForeignKeyAPI.Modules.Endpoints
{
    public class ProductResponse
    {
		public int Id { get; set; }
		public string? Nome { get; set; }
		public string? Fabricante { get; set; }
		public double Preco { get; set; }
		public Group Grupo { get; set; }
    }
}