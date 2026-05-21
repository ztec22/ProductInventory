using Microsoft.AspNetCore.Mvc;

namespace ProductInventory.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private static readonly Product[] products =
    [
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

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
        return products;
    }
}
