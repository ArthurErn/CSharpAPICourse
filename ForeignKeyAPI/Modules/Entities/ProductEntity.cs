namespace ForeignKeyAPI.Modules.Entities
{
    public class Product
    {
		// public Product(string? nome, string? fabricante, double preco, Group grupo){
		// 	Nome = nome;
		// 	Fabricante = fabricante;
		// 	Preco = preco;
		// 	Grupo = grupo;
		// }

        public int Id { get; set; }
		public string? Nome { get; set; }
		public string? Fabricante { get; set; }
		public double Preco { get; set; }
		public Group Grupo { get; set; }
    }
}