using CoreBuisness;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetCategoryByIdUseCase
    {
        Category Execute(int categoryId);
    }
}