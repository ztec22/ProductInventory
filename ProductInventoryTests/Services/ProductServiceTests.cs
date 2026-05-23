using Xunit;
using Moq;
using ProductInventory.Services;
using ProductInventory.Repositories;
using ProductInventory.Models;


namespace ProductInventoryTests.Services;

public class ProductServiceTests
{

    [Fact]
    public async Task GetProducts_Ok()
    {   
        //Arrange
        List<Product> products = [];

        var mockProductRepo = new Mock<IProductRepository>();
        mockProductRepo.Setup(repo => repo.GetProducts()).ReturnsAsync(products);

        var productService = new ProductService(mockProductRepo.Object);

        //Act
        var result = await productService.GetProducts();

        //Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task CreateProduct_Ok()
    {   
        //Arrange
        var product = new Product
        {
            Id = 1,
            Name = "Mouse",
            Category = "Electronics",
            Brand = "Brand 1",
            Vendor = "Vendor 1",
            Price = 6.5,
            Amount = 1,
        };

        var mockProductRepo = new Mock<IProductRepository>();
        mockProductRepo.Setup(repo => repo.CreateProduct(product)).ReturnsAsync(product);

        var productService = new ProductService(mockProductRepo.Object);

        //Act
        var result = await productService.CreateProduct(product);

        //Assert
        Assert.Equal(product.Id, result.Id);
        Assert.Equal(product.Name, result.Name);
        Assert.Equal(product.Category, result.Category);
        Assert.Equal(product.Brand, result.Brand);
        Assert.Equal(product.Vendor, result.Vendor);
        Assert.Equal(product.Price, result.Price);
        Assert.Equal(product.Amount, result.Amount);
    }
}