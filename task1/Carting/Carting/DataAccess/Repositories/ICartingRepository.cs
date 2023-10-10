using Carting.DataAccess.Models;

namespace Carting.DataAccess.Repositories
{
    public interface ICartingRepository
    {
        List<CartItem> GetCartItems(int cartId);
        void AddCartItem(CartItem cartItem);
        void RemoveCartItem(int cartItemId);
    }
}

