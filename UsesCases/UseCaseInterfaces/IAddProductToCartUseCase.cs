using CoreBuisness;

namespace UseCases.UseCaseInterfaces
{
    public interface IAddProductToCartUseCase
    {
        void Execute(ShoppingCart cart, Product product);
        void RemoveProductFromCart(ShoppingCart cart, Product product);
        Task UpdateProductQuantity(ShoppingCart cart, ShoppingCartProduct cartProduct);
    }
}