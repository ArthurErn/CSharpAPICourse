using ForeignKeyAPI.Modules.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForeignKeyAPI.Modules
{
	public class ApplicationDBContext : DbContext
	{
		public DbSet<Group> Group { get; set; }
		public DbSet<Product> Product { get; set; }
		private string connectionString;

		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base()
		{
			var builder = new ConfigurationBuilder();
			builder.AddJsonFile("appsettings.Development.json", optional: false);
			var configuration = builder.Build();
			connectionString = configuration["ConnectionString:Default"];
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(connectionString);
		}
	}
}