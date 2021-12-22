using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

	public DbSet<Product>? Products { get; set; }
	public DbSet<Category>? Category { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<Product>().Property(p => p.Name).HasMaxLength(120).IsRequired();
		builder.Entity<Product>().Property(p => p.Description).HasMaxLength(500).IsRequired(false);
		builder.Entity<Product>().Property(p => p.Code).HasMaxLength(20).IsRequired();
		builder.Entity<Category>().Property(p => p.Name).HasMaxLength(120).IsRequired();
	}
}