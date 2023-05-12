using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBuisness.User
{
    public class AppUser : IdentityUser
    {
        //public Address Address { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; } = new();
    }
}
