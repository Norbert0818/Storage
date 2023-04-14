using CoreBuisness;

namespace UseCases.UseCaseInterfaces
{
    public interface IAddProductToCartUseCase
    {
        void Execute(ShoppingCart cart, Product product);
    }
}