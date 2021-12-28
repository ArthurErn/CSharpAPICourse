using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Entities;
using Npgsql;

namespace PostgreSQLconnect
{
	public class ApplicationDBContext : DbContext
	{
		public DbSet<ProductEntity> Product { get; set; } = null!;
		private string connectionString;

		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base()
		{
			var builder = new ConfigurationBuilder();
			builder.AddJsonFile("appsettings.Development.json", optional: false);
			var configuration = builder.Build();
			connectionString = configuration["ConnectionString:Default"];
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ProductEntity>().HasKey(p => p.Id);

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(connectionString);
		}
	}
}