using System.Collections.Specialized;
using CoreBuisness;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute();
        List<KeyValuePair<Product, int>> ConvertCartProductsToProducts(List<ShoppingCartProduct> cartProducts);
    }
}