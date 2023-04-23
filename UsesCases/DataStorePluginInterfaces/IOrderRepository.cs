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
        Task<int> AddOrderAsync(Orders order);
        void DeleteOrder(int orderId);
        Task<Orders> GetOrderAsync(int orderNumber);
        Task<int> UpdateOrderAsync(Orders order);
        Orders GetOrderByOrderNumber(int orderNumber);
        Task<List<Orders>> GetOrdersByCustomerIdAsync(string customerId);
    }
}
