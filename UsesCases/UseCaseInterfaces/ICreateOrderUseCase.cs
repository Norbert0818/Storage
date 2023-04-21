using CoreBuisness;

namespace UseCases.UseCaseInterfaces
{
    public interface ICreateOrderUseCase
    {
        Task<int> ExecuteAsync(Orders order);
    }
}