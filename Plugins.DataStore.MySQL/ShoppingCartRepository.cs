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
        if (cart == null)
        {
            throw new ArgumentException("Cart must not be null.");
        }

        ShoppingCartProduct shoppingCartProduct = null;
        try
        {
            shoppingCartProduct = cart.CartProducts.Find(cp => cp.ProductId.Equals(product.ProductId));
        }
        catch (Exception e)
        {

        }
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

        cart.CartProducts.Add(shoppingCartProduct);
        db.ShoppingCartProducts.Add(shoppingCartProduct);
        db.ShoppingCarts.Update(cart);
        db.SaveChanges();
    }

    public ShoppingCart GetShoppingCartForUser(string userId)
    {
        if (userId == null)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            db.ShoppingCarts.Add(shoppingCart);
            return shoppingCart;

        }

        return db.ShoppingCarts.Where(sc => sc.UserId == userId).FirstOrDefault();
    }

    public List<ShoppingCartProduct> GetShoppingCartProducts()
    {
        return db.ShoppingCartProducts.ToList();
    }

    public void RemoveProductFromCart(ShoppingCart cart, Product product)
    {
        if (cart == null)
        {
            throw new ArgumentException("Cart must not be null.");
        }

        var shoppingCartProduct = cart.CartProducts.Find(cp => cp.ProductId.Equals(product.ProductId));
        if (shoppingCartProduct != null)
        {
            cart.CartProducts.Remove(shoppingCartProduct);
            db.ShoppingCartProducts.Remove(shoppingCartProduct);
            db.ShoppingCarts.Update(cart);
            db.SaveChanges();
        }
    }

    public async Task UpdateProductQuantity(ShoppingCart cart, ShoppingCartProduct cartProduct)
    {
        var shoppingCartProduct = db.ShoppingCartProducts.FirstOrDefault(cp => cp.Id == cartProduct.Id);
        if (shoppingCartProduct != null)
        {
            shoppingCartProduct.Quantity = cartProduct.Quantity;
            db.ShoppingCartProducts.Update(shoppingCartProduct);
            db.ShoppingCarts.Update(cart);
            await db.SaveChangesAsync();
        }
    }
}