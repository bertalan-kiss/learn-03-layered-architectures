using Carting.Core.Models;

namespace Carting.Core.Services
{
    public interface ICartingService
    {
        List<CartItem> GetCartItems(int cartId);
        void AddCartItem(CartItem cartItem);
        void RemoveCartItem(int cartItemId);
    }
}

