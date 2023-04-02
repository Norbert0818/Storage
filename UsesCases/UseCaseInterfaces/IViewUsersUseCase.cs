using CoreBuisness;
using Microsoft.AspNetCore.Identity;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewUsersUseCase
    {
        IEnumerable<IdentityUser> Execute();

    }
}