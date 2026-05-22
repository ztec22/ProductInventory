using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInventory.Models;

namespace ProductInventory.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductContext _context;

    public ProductController(ProductContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {   
        return Ok(await _context.Products.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null){
            return NotFound();
        }
        
        return Ok(product); 
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        if(product == null){
            return BadRequest();
        }
        
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetProductById), new {id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduct(int id, Product updatedProduct)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null){
            return NotFound();
        }

        product.Name = updatedProduct.Name;
        product.Category = updatedProduct.Category;
        product.Brand = updatedProduct.Brand;
        product.Vendor = updatedProduct.Vendor;
        product.Price = updatedProduct.Price;
        product.Amount = updatedProduct.Amount;

        await _context.SaveChangesAsync();
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if(product != null){
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        
        return NoContent();
    }
}
