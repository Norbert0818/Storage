using CoreBuisness;
using CoreBuisness.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;



namespace Plugins.DataStore.MySQL
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }
        public DbSet<WorkerTask> WorkerTasks { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Worker> Workers { get; set; }
        ///public DbSet<AppUser> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShoppingCartProduct>()
                .HasKey(sp => new { sp.ShoppingCartId, sp.ProductId });

            modelBuilder.Entity<ShoppingCartProduct>()
                .HasOne(sc => sc.ShoppingCart)
                .WithMany(s => s.ShoppingCartProducts)
                .HasForeignKey(sc => sc.ShoppingCartId);

            modelBuilder.Entity<ShoppingCartProduct>()
                .HasOne(sc => sc.Product)
                .WithMany(p => p.ShoppingCartProducts)
                .HasForeignKey(sc => sc.ProductId);

        }
    }
}
