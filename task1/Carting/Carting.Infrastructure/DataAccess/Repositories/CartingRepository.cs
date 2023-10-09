using Carting.Infrastructure.DataAccess.Models;
using LiteDB;

namespace Carting.Infrastructure.DataAccess.Repositories
{
    public class CartingRepository : ICartingRepository
    {
        private const string DatabasePath = "CartingDatabase.db";
        private const string CartItemsTableName = "cart_items";

        public List<CartItem> GetCartItems(int cartId)
        {
            using var db = new LiteDatabase(DatabasePath);

            var collection = db.GetCollection<CartItem>(CartItemsTableName);

            return collection.Find($"$.CartId = {cartId}").ToList();
        }

        public void AddCartItem(CartItem cartItem)
        {
            using var db = new LiteDatabase(DatabasePath);

            var collection = db.GetCollection<CartItem>(CartItemsTableName);
            collection.Insert(cartItem);
        }

        public void RemoveCartItem(int cartItemId)
        {
            using var db = new LiteDatabase(DatabasePath);

            var collection = db.GetCollection<CartItem>(CartItemsTableName);
            collection.Delete(cartItemId);
        }
    }
}

