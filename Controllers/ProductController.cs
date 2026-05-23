using Microsoft.AspNetCore.Mvc;
using ProductInventory.Data;
using ProductInventory.Models;
using ProductInventory.Services;

namespace ProductInventory.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService  _productService;

    public ProductController(AppDbContext context, ProductService  productService)
    {
        _productService =  productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {   
        return Ok(await _productService.GetProducts());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var product = await _productService.GetProductById(id);
        if (product == null){
            return NotFound();
        }
        
        return Ok(product); 
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product productRequest)
    {
        if(productRequest == null){
            return BadRequest();
        }
        
        Product product = await _productService.CreateProduct(productRequest);
        
        return CreatedAtAction(nameof(GetProductById), new {id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduct(int id, Product updatedProduct)
    {
        var product = await _productService.UpdateProduct(id, updatedProduct);
        if (product == null){
            return NotFound();
        }
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProduct(id);

        return NoContent();
    }
}
