using CoreBuisness;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute();

    }
}