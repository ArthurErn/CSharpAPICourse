using Microsoft.EntityFrameworkCore;
using Entities;

namespace PostgreSQLconnect
{
	public class ApplicationDBContext : DbContext
	{

		public DbSet<ProductEntity> Product { get; set; }

		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base() { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ProductEntity>().HasKey(p => p.Id);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseNpgsql(@"Server=192.168.18.65;Port=5432;Database=APICsharp;User Id=postgres;Password=Kalisba987");
		}
	}
}