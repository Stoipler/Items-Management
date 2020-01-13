using ItemsManagement.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItemsManagement.DataAccessLayer.AppContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id=1, Name="Iphone",Type="Phone"},
                new Item { Id=2, Name="Samsung",Type="Laptop"},
                new Item { Id=3, Name="Harry Potter",Type="Book"},
                new Item { Id=4, Name="Iphone",Type="Phone"}
                );
        }
    }
}
