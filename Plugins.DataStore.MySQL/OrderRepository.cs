using CoreBuisness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.MySQL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dbContext;

        public OrderRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<int> AddOrderAsync(Order order)
        //{
        //    _dbContext.Orders.Add(order);
        //    return await _dbContext.SaveChangesAsync();
        //}
        public async Task<int> AddOrderAsync(Order order)
        {
            order.CustomerId = order.ShoppingCart.UserId ?? order.ShoppingCart.AnonId;
            _dbContext.Orders.Add(order);
            return await _dbContext.SaveChangesAsync();
        }
        public void DeleteOrder(int orderId)
        {
            var order = _dbContext.Orders.Find(orderId);
            if (order == null) return;
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }
        public async Task<Order> GetOrderAsync(int orderNumber)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderNumber);
        }
        public async Task<int> UpdateOrderAsync(Order order)
        {
            order.CustomerId = order.ShoppingCart.UserId ?? order.ShoppingCart.AnonId;
            foreach (ShoppingCartProduct shoppingCartProduct in order.ShoppingCart!.ShoppingCartProducts)
            {
                Product product = _dbContext.Products.FirstOrDefault(p => p.Id == shoppingCartProduct.ProductId)!;
                product.Quantity -= shoppingCartProduct.Quantity;
            }
            _dbContext.Orders.Update(order);
            return await _dbContext.SaveChangesAsync();
        }

        public Order GetOrderByOrderNumber(int orderNumber)
        {
            return _dbContext.Orders.FirstOrDefault(o => o.Id == orderNumber);
        }

        public async Task<List<Order>> GetOrdersByCustomerIdAsync(string customerId)
        {
            return await _dbContext.Orders
                .Include(o => o.ShoppingCart)
                    .ThenInclude(s => s!.ShoppingCartProducts)
                        .ThenInclude(p => p.Product)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

    }
}
