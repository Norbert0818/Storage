using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UseCases.DataStorePluginInterfaces;
using System.Threading.Tasks;
using StorageSystem.Data;

namespace Plugins.DataStore.MySQL
{
    public class UserRepository : IUserRepository
    {
        private readonly AccountContext db;

        public UserRepository(AccountContext db)
        {
            this.db = db;
        }

        public IEnumerable<IdentityUser> GetUsers()
        {
            return db.Users.ToList();
        }

    }
}
