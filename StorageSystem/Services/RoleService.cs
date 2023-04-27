using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace StorageSystem.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            var role = new IdentityRole(roleName);
            return await _roleManager.CreateAsync(role);
        }
        public async Task<IdentityResult> DeleteRoleAsync(IdentityRole role)
        {
            return await _roleManager.DeleteAsync(role);
        }

        public async Task<List<IdentityRole>> GetAllRolesAsync()
        {
            return new List<IdentityRole>(await _roleManager.Roles.ToListAsync());
        }

        public async Task<List<IdentityUser>> GetUsersInRoleAsync(string roleName)
        {
            return new List<IdentityUser>(await _userManager.GetUsersInRoleAsync(roleName));
        }

        public async Task<IdentityResult> AddUserToRoleAsync(IdentityUser user, string roleName)
        {
            return await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> RemoveUserFromRoleAsync(IdentityUser user, string roleName)
        {
            return await _userManager.RemoveFromRoleAsync(user, roleName);
        }



    }
}
