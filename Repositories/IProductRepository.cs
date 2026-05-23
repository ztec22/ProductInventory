using ProductInventory.Models;

namespace ProductInventory.Repositories;


public interface IProductRepository
{
    Task<List<Product>> GetProducts();
    Task<Product?> GetProductById(int id);
    Task<Product> CreateProduct(Product product);
    Task<Product?> UpdateProduct(int id, Product updatedProduct);
    Task DeleteProduct(int id);
}