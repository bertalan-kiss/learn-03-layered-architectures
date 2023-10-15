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
        Console.WriteLine("Start");

        var insertedId = await categoryService.Add(new Category
        {
            Name = $"Category_{Guid.NewGuid().ToString()[..8]}",
            Parent = new Category { Id = 23 }
        });

        var item = await categoryService.Get(insertedId);

        Console.WriteLine($"{item.Id} {item.Name} {item.ImageUrl} {item.Parent?.Id}");
        Console.WriteLine();

        await categoryService.Update(new Category
        {
            Id = insertedId,
            Name = "updated",
            ImageUrl = "ImageUrl"
        });

        item = await categoryService.Get(insertedId);

        Console.WriteLine($"{item.Id} {item.Name} {item.ImageUrl} {item.Parent?.Id}");
        Console.WriteLine();

        await categoryService.Delete(insertedId);
        var items = await categoryService.List();

        ListItems(items);

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

