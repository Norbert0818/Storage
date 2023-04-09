using CoreBuisness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.MySQL;

public class ShoppingCartRepository:IShoppingCartRepository
{
    private readonly DataContext db;
    public ShoppingCartRepository(DataContext db)
    {
        this.db = db;
    }

    public ShoppingCart GetShoppingCartForUser(int userId)
    {
        // return new ShoppingCart();
        return db.ShoppingCarts.Where(sc => sc.UserId == userId).FirstOrDefault();
    }
}