using Carting.Core.Models;

namespace Carting.Core.Mappers
{
    public static class Mapper
    {
        public static DataAccess.Models.CartItem Map(CartItem cartItem)
        {
            if (cartItem == null)
                throw new ArgumentNullException(nameof(cartItem));

            return new DataAccess.Models.CartItem
            {
                CartId = cartItem.CartId,
                _id = cartItem.Id,
                Image = new DataAccess.Models.Image
                {
                    Url = cartItem.Image?.Url,
                    Alt = cartItem.Image?.Alt
                },
                Name = cartItem.Name,
                Price = cartItem.Price,
                Quantity = cartItem.Quantity
            };
        }

        public static CartItem Map(DataAccess.Models.CartItem cartItem)
        {
            if (cartItem == null) 
                throw new ArgumentNullException(nameof(cartItem));

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

        public static List<CartItem> Map(List<DataAccess.Models.CartItem> cartItems)
        {
            if (cartItems == null) 
                throw new ArgumentNullException(nameof(cartItems));

            var result = new List<CartItem>();
            cartItems.ForEach(i => result.Add(Map(i)));

            return result;
        }
    }
}

