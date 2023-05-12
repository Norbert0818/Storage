using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBuisness.User
{
    public enum UserRole
    {
        Employee,
        Manager,
        Admin
    }
    public class Worker : AppUser
    {
        public UserRole Role { get; set; }
    }
}
