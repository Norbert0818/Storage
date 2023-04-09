using CoreBuisness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetShoppingCartForUser(int userId);
    }
}