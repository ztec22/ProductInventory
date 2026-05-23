using Microsoft.EntityFrameworkCore;
using ProductInventory.Models;

namespace ProductInventory.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    private List<Product> products = [
        new Product {
            Id = 1,
            Name = "Mouse",
            Category = "Electronics",
            Brand = "Brand 1",
            Vendor = "Vendor 1",
            Price = 6.5,
            Amount = 1,
        },
        new Product {
            Id = 2,
            Name = "Keyboard",
            Category = "Electronics",
            Brand = "Brand 2",
            Vendor = "Vendor 2",
            Price = 9.5,
            Amount = 1,
        },
        new Product {
            Id = 3,
            Name = "Screen",
            Category = "Electronics",
            Brand = "Brand 3",
            Vendor = "Vendor 3",
            Price = 120.6,
            Amount = 1,
        },
    ];
    
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(products);
    }
    
    public DbSet<Product> Products { get; set; } = null!;
}