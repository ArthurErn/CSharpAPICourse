using Microsoft.EntityFrameworkCore;
using Entities;

namespace PostgreSQLconnect
{
	public class ApplicationDBContext : DbContext
	{

		public DbSet<ProductEntity> Product { get; set; }
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base()
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ProductEntity>().HasKey(p => p.Id);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			//options.UseSqlServer(@"Server=localhost;Database=TestingCRUD;User Id=sa;Password=@sql2021;MultipleActiveResultSets=true;Encrypt=YES;TrustServerCertificate=YES");
			options.UseNpgsql(@"Server=<YOUR_HOST>>;Port=<PORT>;Database=<DB>;User Id=postgres;Password=<YOUR_PASSWORD>>");
		}
	}
}