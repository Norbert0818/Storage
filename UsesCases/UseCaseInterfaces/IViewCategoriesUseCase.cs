using CoreBuisness;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
    }
}