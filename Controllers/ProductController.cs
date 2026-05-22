using Microsoft.AspNetCore.Mvc;
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
    public ActionResult<List<Product>> GetProducts()
    {   
        return Ok(_context.Products.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProductById(int id)
    {
        var product = _context.Products.Find(id);
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
        
        _context.Products.Add(product);
        _context.SaveChanges();
        
        return CreatedAtAction(nameof(GetProductById), new {id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateProduct(int id, Product updatedProduct)
    {
        var product = _context.Products.Find(id);
        if (product == null){
            return NotFound();
        }

        product.Name = updatedProduct.Name;
        product.Category = updatedProduct.Category;
        product.Brand = updatedProduct.Brand;
        product.Vendor = updatedProduct.Vendor;
        product.Price = updatedProduct.Price;
        product.Amount = updatedProduct.Amount;

        _context.Products.Update(product);
        _context.SaveChanges();
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(int id)
    {
        var product = _context.Products.Find(id);
        if(product != null){
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        
        return NoContent();
    }
}
