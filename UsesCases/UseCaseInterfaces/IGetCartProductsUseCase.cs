﻿using CoreBuisness;
using Microsoft.AspNetCore.Identity;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetCartProductsUseCase
    {
        List<ShoppingCartProduct> Execute();
    }
}