using CoreBuisness.User;
using Microsoft.AspNetCore.Identity;

namespace StorageSystem.Services
{
    public interface IRoleService
    {
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<List<IdentityRole>> GetAllRolesAsync();
        Task<List<AppUser>> GetUsersInRoleAsync(string roleName);
        Task<IdentityResult> AddUserToRoleAsync(AppUser user, string roleName);
        Task<IdentityResult> RemoveUserFromRoleAsync(AppUser user, string roleName);
        Task<IdentityResult> DeleteRoleAsync(IdentityRole role);

    }
}