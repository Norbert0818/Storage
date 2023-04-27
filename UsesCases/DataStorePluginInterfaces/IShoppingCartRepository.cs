using CoreBuisness;
using Microsoft.AspNetCore.Identity;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetShoppingCartForUser(string userId);
        void AddProductToCart(ShoppingCart shoppingCart, Product product);
        List<Product> GetShoppingCartProducts();
        void RemoveProductFromCart(ShoppingCart shoppingCart, Product product);
        Task UpdateProductQuantity(ShoppingCartProduct shoppingCartProduct);
    }
}