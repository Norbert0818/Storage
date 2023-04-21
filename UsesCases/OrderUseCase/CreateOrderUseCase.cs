using CoreBuisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.OrderUseCase
{
    public class CreateOrderUseCase : ICreateOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> ExecuteAsync(Orders order)
        {
            // Set the order properties that are not set by the cart component
            order.CreatedDate = DateTime.Now;
            order.UpdatedDate = DateTime.Now;
            order.WorkerName = "N/A";
            order.WorkerPhoneNumber = "N/A";
            order.CustomerId = int.Parse(order.CustomerEmail.Split("@")[0]); // Just an example, you might want to use a different way to set the customer id

            // Calculate the total price
            var cartProducts = order.CartProducts;
            var totalPrice = 0.0;
            foreach (var cartProduct in cartProducts)
            {
                var product = cartProduct.Product;
                var price = product.Price ?? 0.0;
                totalPrice += price * cartProduct.Quantity;
            }
            order.TotalDiscount = 0.0; // Just an example, you might want to calculate the discount differently
            order.TotalPrice = totalPrice - order.TotalDiscount;

            // Add the order to the database
            return await _orderRepository.AddOrderAsync(order);
        }
    }
}
