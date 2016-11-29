using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Convertors
{
    public static class CartConvertors
    {
        public static CartItemEntity CartItemToCartItemEntity(this CartItem item)
        {
            return new CartItemEntity
            {
                Id = item.Product?.Id,
                Count = item.Quantity
            };
        }
        public static CartItem CartItemEntityToCartItem(this CartItemEntity item)
        {
            return new CartItem
            {
                Id = item.Id,
                Quantity = item.Count
            };
        }
    }
}
