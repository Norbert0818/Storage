using CoreBuisness;
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
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }
        public DbSet<WorkerTask> WorkerTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

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
