using ProductInventory.Models;
using ProductInventory.Repositories;

namespace ProductInventory.Services;


public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> GetProducts()
    {   
        return await _productRepository.GetProducts();
    }

   
    public async Task<Product?> GetProductById(int id)
    {
        return await _productRepository.GetProductById(id);
        
    }


    public async Task<Product> CreateProduct(Product product)
    {
        await _productRepository.CreateProduct(product);
        
        return product;
    }

    public async Task<Product?> UpdateProduct(int id, Product updatedProduct)
    {
        return await _productRepository.UpdateProduct(id, updatedProduct);
    }


    public async Task DeleteProduct(int id)
    {
        await _productRepository.DeleteProduct(id);
    }
}