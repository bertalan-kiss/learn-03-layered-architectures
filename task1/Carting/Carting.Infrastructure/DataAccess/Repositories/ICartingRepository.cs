using Carting.Infrastructure.DataAccess.Models;

namespace Carting.Infrastructure.DataAccess.Repositories
{
    public interface ICartingRepository
    {
        List<CartItem> GetCartItems(int cartId);
        void AddCartItem(CartItem cartItem);
        void RemoveCartItem(int cartItemId);
    }
}

