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

    public ShoppingCart GetShoppingCartForUser(string userId)
    {

        //ShoppingCart pendingCart = db.ShoppingCarts
        //    .Where(sc => sc.UserId == userId && sc.Order.Status == OrderStatusEnum.Pending)
        //    .Include(sc => sc.ShoppingCartProducts)
        //        .ThenInclude(scp => scp.Product)
        //    .FirstOrDefault()!;

        if (userId == null)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            db.ShoppingCarts.Add(shoppingCart);
            return shoppingCart;

        }


        return db.ShoppingCarts
            .Where(sc => sc.UserId == userId)
            .Include(sc => sc.ShoppingCartProducts)
                .ThenInclude(scp => scp.Product)
            .FirstOrDefault()!;
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