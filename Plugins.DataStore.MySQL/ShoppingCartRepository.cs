using CoreBuisness;
using Microsoft.EntityFrameworkCore;
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

    public void AddProductToCart(ShoppingCart shoppingCart, Product product)
    {
        if (shoppingCart == null)
        {
            throw new ArgumentException("Cart must not be null.");
        }

        ShoppingCartProduct shoppingCartProduct = null;
        try
        {
            shoppingCartProduct = shoppingCart.ShoppingCartProducts.Find(scp => scp.ProductId == product.Id && scp.ShoppingCartId == shoppingCart.Id)!;
        }
        catch
        {

        }
        if (shoppingCartProduct != null)
        {
            shoppingCartProduct.Quantity += 1;
        }
        else
        {
            shoppingCartProduct = new()
            {
                ShoppingCart = shoppingCart,
                Product = product,
                Quantity = 1
            };

            shoppingCart.ShoppingCartProducts.Add(shoppingCartProduct);
            //db.ShoppingCartProducts.Add(shoppingCartProduct);
        }

        db.ShoppingCarts.Update(shoppingCart);
        db.SaveChanges();
    }

    // doksiba
    public ShoppingCart GetShoppingCartForUser(string? userId, string? anonId = null)
    {

        ShoppingCart? shoppingCart2 = db.ShoppingCarts
            .Where(sc => sc.UserId == userId || sc.AnonId == anonId)
            .Where(sc => sc.Order == null)
            .Include(sc => sc.Order)
            .Include(sc => sc.ShoppingCartProducts)
                .ThenInclude(scp => scp.Product)
            .OrderBy(sp => sp.Id)
            .LastOrDefault()!;

        if (shoppingCart2 == null)
        {
            if (userId == null)
            {
                ShoppingCart shoppingCart = new ShoppingCart()
                {
                    AnonId = anonId
                };
                db.ShoppingCarts.Add(shoppingCart);
                db.SaveChanges();
                return shoppingCart;

            }
            else
            {
                ShoppingCart shoppingCart3 = new ShoppingCart()
                {
                    UserId = userId
                };
                db.ShoppingCarts.Add(shoppingCart3);
                db.SaveChanges();
                return shoppingCart3;
            }
        }
        else
        {
            return shoppingCart2;
        }
    }

    public List<Product> GetShoppingCartProducts()
    {
        return db.Products.ToList();
    }

    public void RemoveProductFromCart(ShoppingCart shoppingCart, Product product)
    {
        if (shoppingCart == null)
        {
            throw new ArgumentException("Cart must not be null.");
        }

        var shoppingCartProduct = shoppingCart.ShoppingCartProducts.Find(scp => scp.ProductId == product.Id && scp.ShoppingCartId == shoppingCart.Id);
        if (shoppingCartProduct != null)
        {
            shoppingCart.ShoppingCartProducts.Remove(shoppingCartProduct);
            db.ShoppingCarts.Update(shoppingCart);
            db.SaveChanges();
        }
    }

    public async Task UpdateProductQuantity(ShoppingCartProduct shoppingCartProduct)
    {
        db.ShoppingCartProducts.Update(shoppingCartProduct);
        await db.SaveChangesAsync();
    }
}