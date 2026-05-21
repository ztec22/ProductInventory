using Microsoft.AspNetCore.Mvc;
using ProductInventory.Models;

namespace ProductInventory.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    static private List<Product> products =
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

    [HttpGet]
    public ActionResult<List<Product>> GetProducts()
    {
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProductById(int id)
    {
        var product = products.Find(p => p.Id == id);
        if (product == null){
            return NotFound();
        }
        
        return Ok(product); 
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
        if(product == null){
            return BadRequest();
        }
        
        products.Add(product);
        return CreatedAtAction(nameof(GetProductById), new {id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateProduct(int id, Product updatedProduct)
    {
        var product = products.Find(p => p.Id == id);
        if (product == null){
            return NotFound();
        }

        product.Name = updatedProduct.Name;
        product.Category = updatedProduct.Category;
        product.Brand = updatedProduct.Brand;
        product.Vendor = updatedProduct.Vendor;
        product.Price = updatedProduct.Price;
        product.Amount = updatedProduct.Amount;
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(int id)
    {
        var product = products.Find(p => p.Id == id);
        if(product != null){
            products.Remove(product);
        }
        
        return NoContent();
    }
}
