using CoreBuisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IOrderRepository
    {
        Task<int> AddOrderAsync(Order order);
        void DeleteOrder(int orderId);
        Task<Order> GetOrderAsync(int orderNumber);
        Task<int> UpdateOrderAsync(Order order);
        Order GetOrderByOrderNumber(int orderNumber);
        Task<List<Order>> GetOrdersByCustomerIdAsync(string customerId);
    }
}
