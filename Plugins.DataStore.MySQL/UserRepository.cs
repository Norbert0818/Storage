using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UseCases.DataStorePluginInterfaces;
using System.Threading.Tasks;
using CoreBuisness.User;

namespace Plugins.DataStore.MySQL
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext db;

        public UserRepository(DataContext db)
        {
            this.db = db;
        }

        public IEnumerable<AppUser> GetUsers()
        {
            return db.Users.ToList();
        }

    }
}
