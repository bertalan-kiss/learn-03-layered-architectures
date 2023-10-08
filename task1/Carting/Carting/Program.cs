using Carting.Core;
using Carting.Core.Services;
using Carting.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Carting;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddCoreServices()
            .AddInfrastuctureRepositories()
            .BuildServiceProvider();

        var cartingService = serviceProvider.GetService<ICartingService>();

        var cartId = new Random().Next();

        cartingService.AddCartItem(new Core.Models.CartItem
        {
            CartId = cartId,
            Name = $"CartItem_{new Random().Next()}",
            Price = new Random().Next(10, 1000000),
            Quantity = new Random().Next(1, 10)
        });

        var cartItems = cartingService.GetCartItems(cartId);

        cartingService.RemoveCartItem(cartItems.First().Id);

        var result = cartingService.GetCartItems(cartId);
    }
}

