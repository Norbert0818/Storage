using CoreBuisness;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CartUseCase
{
    public class GetCartProductsUseCase : IGetCartProductsUseCase
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        
        public GetCartProductsUseCase(IShoppingCartRepository shoppingCartRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public List<ShoppingCartProduct> Execute()
        {
            return shoppingCartRepository.GetShoppingCartProducts();
        }
    }
}
