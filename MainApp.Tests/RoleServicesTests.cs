using CoreBuisness.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StorageSystem.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Moq.Language.Flow;



namespace MainApp.Tests
{
    [TestClass]
    public class RoleServiceTests
    {
        private RoleService _roleService;
        private Mock<RoleManager<IdentityRole>> _mockRoleManager;
        private Mock<UserManager<AppUser>> _mockUserManager;

        [TestInitialize]
        public void Setup()
        {
            _mockRoleManager = new Mock<RoleManager<IdentityRole>>(
                Mock.Of<IRoleStore<IdentityRole>>(),
                null, null, null, null);

            _mockUserManager = new Mock<UserManager<AppUser>>(
                Mock.Of<IUserStore<AppUser>>(), null, null, null, null, null, null, null, null);

            _roleService = new RoleService(_mockRoleManager.Object, _mockUserManager.Object);
        }

        [TestMethod]
        public async Task CreateRoleAsync_ValidRoleName_ReturnsIdentityResultSuccess()
        {
            // Arrange
            string roleName = "TestRole";

            _mockRoleManager.Setup(rm => rm.CreateAsync(It.IsAny<IdentityRole>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _roleService.CreateRoleAsync(roleName);

            // Assert
            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public async Task DeleteRoleAsync_ValidRole_ReturnsIdentityResultSuccess()
        {
            // Arrange
            var role = new IdentityRole("TestRole");

            _mockRoleManager.Setup(rm => rm.DeleteAsync(It.IsAny<IdentityRole>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _roleService.DeleteRoleAsync(role);

            // Assert
            Assert.IsTrue(result.Succeeded);
        }



        [TestMethod]
        public async Task GetUsersInRoleAsync_ValidRoleName_ReturnsListOfUsers()
        {
            // Arrange
            string roleName = "TestRole";
            var users = new List<AppUser>
            {
                new AppUser { UserName = "User1" },
                new AppUser { UserName = "User2" }
            };

            _mockUserManager.Setup(um => um.GetUsersInRoleAsync(roleName))
                .ReturnsAsync(users);

            // Act
            var result = await _roleService.GetUsersInRoleAsync(roleName);

            // Assert
            Assert.AreEqual(users.Count, result.Count);
            Assert.AreEqual(users[0].UserName, result[0].UserName);
            Assert.AreEqual(users[1].UserName, result[1].UserName);
        }

        [TestMethod]
        public async Task AddUserToRoleAsync_ValidUserAndRole_ReturnsIdentityResultSuccess()
        {
            // Arrange
            var user = new AppUser();
            string roleName = "TestRole";

            _mockUserManager.Setup(um => um.AddToRoleAsync(user, roleName))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _roleService.AddUserToRoleAsync(user, roleName);

            // Assert
            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public async Task RemoveUserFromRoleAsync_ValidUserAndRole_ReturnsIdentityResultSuccess()
        {
            // Arrange
            var user = new AppUser();
            string roleName = "TestRole";

            _mockUserManager.Setup(um => um.RemoveFromRoleAsync(user, roleName))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _roleService.RemoveUserFromRoleAsync(user, roleName);

            // Assert
            Assert.IsTrue(result.Succeeded);
        }
    }
}
