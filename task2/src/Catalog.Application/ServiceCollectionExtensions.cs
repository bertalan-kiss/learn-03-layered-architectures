using Catalog.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddSingleton<ICategoryService, CategoryService>();
            collection.AddSingleton<IItemService, ItemService>();
            return collection;
        }
    }
}

