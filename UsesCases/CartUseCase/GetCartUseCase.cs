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
    public class GetCartUseCase : IGetCartUseCase
    {
        private readonly IShoppingCartRepository shoppingCartRepository;

        public GetCartUseCase(IShoppingCartRepository shoppingCartRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public ShoppingCart Execute(string? userId, string? anonId = null)
        {
            return shoppingCartRepository.GetShoppingCartForUser(userId, anonId);
        }
    }
}
