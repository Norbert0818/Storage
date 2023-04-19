﻿using CoreBuisness;

namespace UseCases.UseCaseInterfaces
{
    public interface IAddProductToCartUseCase
    {
        void Execute(ShoppingCart cart, Product product);
        void RemoveProductFromCart(ShoppingCart cart, Product product);
        void UpdateProductQuantity(ShoppingCart cart, Product product, int newQuantity);

    }
}