using Microsoft.EntityFrameworkCore;
using ProductInventory.Data;
using ProductInventory.Models;

namespace ProductInventory.Repositories;


public class ProductRepository: IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> GetProducts()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetProductById(int id)
    {
        return await _dbContext.Products.FindAsync(id);
    }

    public async Task<Product> CreateProduct(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> UpdateProduct(int id, Product updatedProduct)
    {
        var product = await _dbContext.Products.FindAsync(id);
        if (product == null){
            return null;
        }

        product.Name = updatedProduct.Name;
        product.Category = updatedProduct.Category;
        product.Brand = updatedProduct.Brand;
        product.Vendor = updatedProduct.Vendor;
        product.Price = updatedProduct.Price;
        product.Amount = updatedProduct.Amount;

        await _dbContext.SaveChangesAsync();
        
        return product;
    }

    public async Task DeleteProduct(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        if(product != null){
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}