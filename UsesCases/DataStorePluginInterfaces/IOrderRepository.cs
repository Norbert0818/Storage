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
    }
}
