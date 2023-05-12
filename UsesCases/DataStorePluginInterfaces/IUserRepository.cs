using CoreBuisness;
using CoreBuisness.User;
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
        IEnumerable<AppUser> GetUsers();
        // void AddUser(AppUser user);
        // void UpdateUser(AppUser user);
        // Product GetUserById(int userId);
        // void DeleteUser(int userId);
    }
}