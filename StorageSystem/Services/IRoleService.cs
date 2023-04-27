using Microsoft.AspNetCore.Identity;

namespace StorageSystem.Services
{
    public interface IRoleService
    {
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<List<IdentityRole>> GetAllRolesAsync();
        Task<List<IdentityUser>> GetUsersInRoleAsync(string roleName);
        Task<IdentityResult> AddUserToRoleAsync(IdentityUser user, string roleName);
        Task<IdentityResult> RemoveUserFromRoleAsync(IdentityUser user, string roleName);
        Task<IdentityResult> DeleteRoleAsync(IdentityRole role);

    }
}