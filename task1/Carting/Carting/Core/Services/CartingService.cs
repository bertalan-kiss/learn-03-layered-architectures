using Carting.Core.Mappers;
using Carting.Core.Models;
using Carting.DataAccess.Repositories;

namespace Carting.Core.Services
{
    public class CartingService : ICartingService
	{
        private readonly ICartingRepository _cartingRepository;

        public CartingService(ICartingRepository cartingRepository)
        {
            _cartingRepository = cartingRepository;
        }

        public List<CartItem> GetCartItems(int cartId)
        {
            return Mapper.Map(_cartingRepository.GetCartItems(cartId));
        }

        public void AddCartItem(CartItem cartItem)
        {
            _cartingRepository.AddCartItem(Mapper.Map(cartItem));
        }

        public void RemoveCartItem(int cartItemId)
        {
            _cartingRepository.RemoveCartItem(cartItemId);
        }
    }
}

