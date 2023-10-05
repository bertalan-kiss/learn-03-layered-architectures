using Carting.Core.Models;

namespace Carting.Core.Services
{
    public interface ICartingService
    {
        List<CartItem> GetCartItems(Guid cartId);
        void AddCartItem(Guid cartId, CartItem cartItem);
        void RemoveCartItem(Guid cartId, int cartItemId);
    }
}

