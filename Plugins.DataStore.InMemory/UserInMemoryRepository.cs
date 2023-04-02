using CoreBuisness;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class UserInMemoryRepository : IUserRepository
    {
        private List<IdentityUser> users;

        public UserInMemoryRepository()
        {
            // Init with default values
            users = new List<IdentityUser>()
            {
                new IdentityUser { Email = "test@user.com"},
                new IdentityUser { Email = "test2@user.com"},
            };
        }


        public IEnumerable<IdentityUser> GetUsers()
        {
            return users;
        }

    //    public void UpdateProduct(Product product)
    //    {
    //        var productToUpdate = GetProductById(product.ProductId);
    //        if (productToUpdate != null)
    //        {
    //            productToUpdate.Name = product.Name;
    //            productToUpdate.CategoryId = product.CategoryId;
    //            productToUpdate.Price = product.Price;
    //            productToUpdate.Quantity = product.Quantity;
    //        }
    //    }

    //    public Product GetProductById(int productId)
    //    {
    //        return products.FirstOrDefault(x => x.ProductId == productId);
    //    }

    //    public void DeleteProduct(int productId)
    //    {
    //        var productToDelete = GetProductById(productId);
    //        if (productToDelete != null) products.Remove(productToDelete);
    //    }

    //    public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
    //    {
    //        return products.Where(x => x.CategoryId == categoryId);
    //    }
    }
}
