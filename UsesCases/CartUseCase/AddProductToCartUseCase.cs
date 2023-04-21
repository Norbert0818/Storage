using CoreBuisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CartUseCase
{
    public class AddProductToCartUseCase : IAddProductToCartUseCase
    {
        private readonly IShoppingCartRepository shoppingCartRepository;

        public AddProductToCartUseCase(IShoppingCartRepository shoppingCartRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public void Execute(ShoppingCart cart, Product product)
        {
            shoppingCartRepository.AddProductToCart(cart, product);
        }
        public void RemoveProductFromCart(ShoppingCart cart, Product product)
        {
            shoppingCartRepository.RemoveProductFromCart(cart, product);
        }
        public async Task UpdateProductQuantity(ShoppingCart cart, ShoppingCartProduct cartProduct)
        {
            await shoppingCartRepository.UpdateProductQuantity(cart, cartProduct);
        }

    }
}
