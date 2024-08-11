using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Infrastructure.DbContexts;
using NodaTime.TimeZones;
using Testcontainers.PostgreSql;
using Testcontainers.Redis;

namespace Application.Tests.Integration;

public class IntegrationTestWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
        .WithDatabase("CustomerLoyaltyDB_Test")
        .WithUsername("postgres")
        .WithPassword("mysecretpassword")
        .Build();

    private readonly RedisContainer _redisContainer = new RedisBuilder()
        .WithImage("redis:latest")
        .Build();

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
        await _redisContainer.StartAsync();

        using (var scope = Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var dbContext = scopedServices.GetRequiredService<CustomerLoyaltyDBContext>();

            await dbContext.Database.EnsureCreatedAsync();
        }
    }

    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
        await _redisContainer.StopAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            // config for postgres
            var descriptor = services.SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<CustomerLoyaltyDBContext>));
            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<CustomerLoyaltyDBContext>(options =>
            {
                options.UseNpgsql(_dbContainer.GetConnectionString());
            });

            // config for Redis
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = _redisContainer.GetConnectionString();
            });
        });
    }
}