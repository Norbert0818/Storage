using CoreBuisness;
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

        public async Task<int> AddOrderAsync(Orders order)
        {
            _dbContext.Orders.Add(order);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
