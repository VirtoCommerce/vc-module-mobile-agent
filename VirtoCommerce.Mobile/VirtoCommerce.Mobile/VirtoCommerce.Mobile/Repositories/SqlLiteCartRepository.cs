using SQLite;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Interfaces;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.Repositories
{
    public class SqlLiteCartRepository : ICartRepository
    {
        private readonly SQLiteConnection _connection;

        public SqlLiteCartRepository()
        {
            _connection = DependencyService.Get<ISqlLiteConnection>().GetConnection();
            _connection.CreateTable<CartItemEntity>();
        }
        public bool AddOrUpdateCartItem(CartItemEntity cartItem)
        {
            return (_connection.Table<CartItemEntity>().FirstOrDefault(x => x.Id == cartItem.Id) == null ? _connection.Insert(cartItem) : _connection.Update(cartItem)) != -1;
        }

        public bool RemoveCartItem(string id)
        {
            return _connection.Table<CartItemEntity>().Delete(x => x.Id == id) != -1;
        }

        public ICollection<CartItemEntity> GetAllCartItems()
        {
            return _connection.Table<CartItemEntity>().ToList();
        }

        public CartItemEntity GetCartItem(string id)
        {
            return _connection.Table<CartItemEntity>().FirstOrDefault(x => x.Id == id);
        }

        public bool ClearCart()
        {
            var items = _connection.Table<CartItemEntity>().ToList();
            foreach (var item in items)
            {
                _connection.Table<CartItemEntity>().Delete(x => item.Id == x.Id);
            }
            return true;
        }

        public int CountInCart()
        {
            return _connection.Table<CartItemEntity>().Sum(x => x.Count);
        }
    }
}
