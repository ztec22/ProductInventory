namespace ProductInventory.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Category { get; set; }
    public string? Brand { get; set; }
    public string? Vendor { get; set; }
    public required double Price { get; set; }
    public int Amount { get; set; } 
    
}
