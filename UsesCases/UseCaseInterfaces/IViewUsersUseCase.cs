using CoreBuisness;
using CoreBuisness.User;
using Microsoft.AspNetCore.Identity;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewUsersUseCase
    {
        IEnumerable<AppUser> Execute();

    }
}