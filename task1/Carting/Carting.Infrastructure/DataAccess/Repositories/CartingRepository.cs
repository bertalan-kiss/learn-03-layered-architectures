using Carting.Infrastructure.DataAccess.Models;
using LiteDB;

namespace Carting.Infrastructure.DataAccess.Repositories
{
    public class CartingRepository : ICartingRepository
    {
        private readonly string DatabasePath = "CartingDatabase.db";

        public List<CartItem> GetCartItems(int cartId)
        {
            using var db = new LiteDatabase(DatabasePath);

            var collection = db.GetCollection<CartItem>("cart_items");

            return collection.Find($"$.CartId = {cartId}").ToList();
        }

        public void AddCartItem(CartItem cartItem)
        {
            using var db = new LiteDatabase(DatabasePath);

            var collection = db.GetCollection<CartItem>("cart_items");
            collection.Insert(cartItem);
        }

        public void RemoveCartItem(int cartItemId)
        {
            using var db = new LiteDatabase(DatabasePath);

            var collection = db.GetCollection<CartItem>("cart_items");
            collection.Delete(cartItemId);
        }
    }
}

