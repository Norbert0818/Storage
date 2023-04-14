using CoreBuisness;
using System.Reflection.PortableExecutable;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.MySQL;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly DataContext db;
    public ShoppingCartRepository(DataContext db)
    {
        this.db = db;
    }

    public void AddProductToCart(ShoppingCart cart, Product product)
    {
        ShoppingCartProduct shoppingCartProduct = cart.CartProducts.Find(cp => cp.ProductId.Equals(product.ProductId));
        if (shoppingCartProduct != null)
        {
            shoppingCartProduct.Quantity += 1;
        }
        else
        {
            shoppingCartProduct = new ShoppingCartProduct();
            shoppingCartProduct.ProductId = product.ProductId;
            shoppingCartProduct.Quantity = 1;
        }

        db.ShoppingCartProducts.Add(shoppingCartProduct);
        db.SaveChanges();
    }

    public ShoppingCart GetShoppingCartForUser(string userId)
    {
        // return new ShoppingCart();
        if (userId == null)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            db.ShoppingCarts.Add(shoppingCart);
            return shoppingCart;

        }

        return db.ShoppingCarts.Where(sc => sc.UserId == userId).FirstOrDefault();
    }

}