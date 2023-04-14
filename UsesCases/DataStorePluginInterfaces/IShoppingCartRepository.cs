using CoreBuisness;
using Microsoft.AspNetCore.Identity;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetShoppingCartForUser(int userId);
        void AddProductToCart(ShoppingCart cart, Product product);
        ShoppingCart GetCart(IdentityUser user);
    }
}