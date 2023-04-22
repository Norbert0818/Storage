using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.OrderUseCase
{
    public class DeleteOrderUseCase : IDeleteOrderUseCase
    {
        private readonly IOrderRepository orderRepository;
        public DeleteOrderUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public void Execute(int orderId)
        {
            orderRepository.DeleteOrder(orderId);
        }
    }
}
