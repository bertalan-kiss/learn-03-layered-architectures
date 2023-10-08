using Carting.Core.Models;

namespace Carting.Core.Mappers
{
    public static class Mapper
    {
        public static Infrastructure.DataAccess.Models.CartItem Map(CartItem cartItem)
        {
            return new Infrastructure.DataAccess.Models.CartItem
            {
                CartId = cartItem.CartId,
                _id = cartItem.Id,
                Image = new Infrastructure.DataAccess.Models.Image
                {
                    Url = cartItem.Image?.Url,
                    Alt = cartItem.Image?.Alt
                },
                Name = cartItem.Name,
                Price = cartItem.Price,
                Quantity = cartItem.Quantity
            };
        }

        public static CartItem Map(Infrastructure.DataAccess.Models.CartItem cartItem)
        {
            return new CartItem
            {
                CartId = cartItem.CartId,
                Id = cartItem._id,
                Image = new Image
                {
                    Url = cartItem.Image.Url,
                    Alt = cartItem.Image.Alt
                },
                Name = cartItem.Name,
                Price = cartItem.Price,
                Quantity = cartItem.Quantity
            };
        }

        public static List<CartItem> Map(List<Infrastructure.DataAccess.Models.CartItem> cartItems)
        {
            var result = new List<CartItem>();
            cartItems.ForEach(i => result.Add(Map(i)));

            return result;
        }
    }
}

