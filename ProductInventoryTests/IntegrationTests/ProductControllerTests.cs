using System.Net.Http.Json;
using Xunit;
using ProductInventory.Models;


namespace ProductInventoryTests.IntegrationTests;


public class ProductControllerTests : IClassFixture<PostgreSQLFixture>
{

    private readonly HttpClient _client;

    public ProductControllerTests(PostgreSQLFixture fixture)
    {   
        var factory = new CustomWebApplicationFactory(fixture.ConnectionString);
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_Products_Ok()
    {

        //Act
        var response = await _client.GetAsync("/Product/");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<List<Product>>();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        
    }

    [Fact]
    public async Task Post_CreateProduct_Ok()
    {
        //Arrange
        var product = new Product{
            Id = 4,
            Name = "New Product",
            Category = "Electronics",
            Brand = "Brand 4",
            Vendor = "Vendor 4",
            Price = 68.5,
            Amount = 2,
        };

        //Act
        var response = await _client.PostAsJsonAsync("/Product/", product);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<Product>();

        //Assert
        Assert.NotNull(result);
        Assert.Equal(product.Id, result.Id);
        Assert.Equal(product.Name, result.Name);
        Assert.Equal(product.Category, result.Category);
        Assert.Equal(product.Brand, result.Brand);
        Assert.Equal(product.Vendor, result.Vendor);
        Assert.Equal(product.Price, result.Price);
        Assert.Equal(product.Amount, result.Amount);
        
    }

}