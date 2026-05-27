using Microsoft.EntityFrameworkCore;
using ProductInventory.Data;
using Testcontainers.PostgreSql;

namespace ProductInventoryTests.IntegrationTests;

public class PostgreSQLFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder("postgres:17").Build();
    public string ConnectionString => _postgreSqlContainer.GetConnectionString();

    public async Task InitializeAsync()
    {
        await _postgreSqlContainer.StartAsync();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(ConnectionString)
            .Options;

        using var dbContext = new AppDbContext(options);

        // Run migrations
        await dbContext.Database.MigrateAsync();
    }

    public async Task DisposeAsync()
    {
        await _postgreSqlContainer.DisposeAsync().AsTask();
    }

}