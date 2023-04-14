using CoreBuisness;
using Microsoft.AspNetCore.Identity;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetCartUseCase
    {
        ShoppingCart Execute(IdentityUser user);
    }
}