using System.Data;
using Catalog.Application.Services;
using Catalog.Domain.Entities;
using Catalog.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.ConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {
        // Sample console application to try out the services
        var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);

        IConfiguration config = builder.Build();
        var databaseConfiguration = config.GetSection("DatabaseConfiguration").Get<DatabaseConfiguration>();

        var serviceProvider = new ServiceCollection()
            .AddApplicationServices()
            .AddApplicationValidators()
            .AddInfrastructureServices()
            .AddSingleton<IDbConnection>(connection => new SqlConnection(databaseConfiguration.ConnectionString))
            .BuildServiceProvider();

        var categoryService = serviceProvider.GetService<ICategoryService>();
        var itemService = serviceProvider.GetService<IItemService>();
        
        var insertedCategoryId = await categoryService.Add(new Category
        {
            Name = $"Category_{Guid.NewGuid()}",
            Parent = new Category { Id = 23 }
        });

        var category = await categoryService.Get(insertedCategoryId);

        await categoryService.Update(new Category
        {
            Id = insertedCategoryId,
            Name = "updated",
            ImageUrl = "ImageUrl"
        });

        category = await categoryService.Get(insertedCategoryId);

        await categoryService.Delete(insertedCategoryId);

        var categories = await categoryService.List();

        insertedCategoryId = await categoryService.Add(new Category
        {
            Name = $"Category_{Guid.NewGuid()}",
            Parent = new Category { Id = 23 }
        });

        var insertedItemId = await itemService.Add(new Item
        {
            Name = $"Item_{Guid.NewGuid()}",
            Category = new Category { Id = insertedCategoryId },
            Price = 100,
            Amount = 2
        });

        await itemService.Update(new Item
        {
            Id = insertedItemId,
            Name = $"Item_{Guid.NewGuid()}",
            Category = new Category { Id = insertedCategoryId },
            Description = "Description",
            Price = 100,
            Amount = 10
        });

        var insertedItem = await itemService.Get(insertedItemId);

        await itemService.Delete(insertedItemId);

        var items = await itemService.List();

        Console.WriteLine("End");
    }
}

public class DatabaseConfiguration
{
    public string ConnectionString { get; set; }
}

