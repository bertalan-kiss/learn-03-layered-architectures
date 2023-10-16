using Catalog.Application.Services;
using Catalog.Domain.Entities;
using Catalog.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.ConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddApplicationServices()
            .AddInfrastructureServices()
            .BuildServiceProvider();

        var categoryService = serviceProvider.GetService<ICategoryService>();
        var itemService = serviceProvider.GetService<IItemService>();
        Console.WriteLine("Start");

        var insertedCategoryId = await categoryService.Add(new Category
        {
            Name = $"Category_{Guid.NewGuid().ToString()}",
            Parent = new Category { Id = 23 }
        });

        var item = await categoryService.Get(insertedCategoryId);

        //Console.WriteLine($"{item.Id} {item.Name} {item.ImageUrl} {item.Parent?.Id}");
        //Console.WriteLine();

        //await categoryService.Update(new Category
        //{
        //    Id = insertedId,
        //    Name = "updated",
        //    ImageUrl = "ImageUrl"
        //});

        //item = await categoryService.Get(insertedId);

        //Console.WriteLine($"{item.Id} {item.Name} {item.ImageUrl} {item.Parent?.Id}");
        //Console.WriteLine();

        //await categoryService.Delete(insertedId);
        //var items = await categoryService.List();

        //ListItems(items);

        var insertedItemId = await itemService.Add(new Item
        {
            Name = $"Item_{Guid.NewGuid().ToString()[..8]}",
            Category = new Category { Id = insertedCategoryId },
            Price = 100,
            Amount = 2
        });

        await itemService.Update(new Item
        {
            Id = insertedItemId,
            Name = $"Item_{Guid.NewGuid().ToString()[..8]}",
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

    private static void ListItems(IEnumerable<Category> items)
    {
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Id} {item.Name} {item.ImageUrl} {item.Parent?.Id}");
        }

        Console.WriteLine();
    }
}

