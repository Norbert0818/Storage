using CoreBuisness;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IUserRepository
    {
        IEnumerable<IdentityUser> GetUsers();
        // void AddUser(IdentityUser user);
        // void UpdateUser(IdentityUser user);
        // Product GetUserById(int userId);
        // void DeleteUser(int userId);
    }
}