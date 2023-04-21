using CoreBuisness;
using Microsoft.AspNetCore.Identity;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetShoppingCartForUser(string userId);
        void AddProductToCart(ShoppingCart cart, Product product);
        List<ShoppingCartProduct> GetShoppingCartProducts();
        void RemoveProductFromCart(ShoppingCart cart, Product product);
        Task UpdateProductQuantity(ShoppingCart cart, ShoppingCartProduct cartProduct);
    }
}