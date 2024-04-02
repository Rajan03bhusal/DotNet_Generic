using GenericProject.Model;
using Microsoft.EntityFrameworkCore;

namespace GenericProject.Context
{
    public class MyDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public MyDbContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasOne(o => o.Product)
            .WithMany(p => p.Orders)
            .HasForeignKey(o => o.ProductId);
        }
    }
}
