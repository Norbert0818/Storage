using Moq;
using CoreBuisness;
using CoreBuisness.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Plugins.DataStore.MySQL;
using StorageSystem.Pages.Components;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq.EntityFrameworkCore;

namespace MainApp.Tests
{
    [TestClass]
    public class AdminOrdersManagementComponentTests
    {
        [TestMethod]
        public async Task AdminOrdersManagementComponent_ValidInputs_UpdatesAndAssignsOrders()
        {
            // Arrange
            var mockDbContext = new Mock<DataContext>();

            var userStoreMock = new Mock<IUserStore<AppUser>>();
            var userManagerOptions = new Mock<IOptions<IdentityOptions>>();
            var passwordHasher = new Mock<IPasswordHasher<AppUser>>();
            var userValidators = new List<IUserValidator<AppUser>>();
            var passwordValidators = new List<IPasswordValidator<AppUser>>();
            var keyNormalizer = new Mock<ILookupNormalizer>();
            var errors = new Mock<IdentityErrorDescriber>();
            var services = new Mock<IServiceProvider>();
            var logger = new Mock<ILogger<UserManager<AppUser>>>();

            var mockUserManager = new Mock<UserManager<AppUser>>(
                userStoreMock.Object,
                userManagerOptions.Object,
                passwordHasher.Object,
                userValidators,
                passwordValidators,
                keyNormalizer.Object,
                errors.Object,
                services.Object,
                logger.Object);


            var roleStore = new Mock<IRoleStore<IdentityRole>>();
            var roleValidators = new List<IRoleValidator<IdentityRole>>();
            var lookupNormalizer = new Mock<ILookupNormalizer>();
            var identityErrorDescriber = new Mock<IdentityErrorDescriber>();
            var logger2 = new Mock<ILogger<RoleManager<IdentityRole>>>();

            var mockRoleManager = new Mock<RoleManager<IdentityRole>>(
                roleStore.Object,
                roleValidators,
                lookupNormalizer.Object,
                identityErrorDescriber.Object,
                logger2.Object);

            var expectedOrder = new Order
            {
                Id = 1,
                ShoppingCartId = 5,
                Status = 0,
                // Fill other properties
            };

            var expectedOrders = new List<Order>
            {
                expectedOrder,

            };

            var expectedShoppingCart = new ShoppingCart
            {
                Id = expectedOrder.ShoppingCartId,
                // Define other properties here
            };

            var expectedShoppingCarts = new List<ShoppingCart>
            {
                expectedShoppingCart,
                // Add other ShoppingCart objects
            };

            var expectedShoppingCartProduct = new ShoppingCartProduct
            {

                ShoppingCartId = 5,
                ProductId = 2
                // Define properties here, especially ProductId and ShoppingCartId
            };

            var expectedShoppingCartProducts = new List<ShoppingCartProduct>
            {
                expectedShoppingCartProduct,
                // Add other ShoppingCartProduct objects
            };

            var expectedProduct = new Product
            {
                Id = expectedShoppingCartProduct.ProductId,
                // Define other properties here
            };

            var expectedProducts = new List<Product>
            {
                expectedProduct,
                // Add other Product objects
            };

            Assert.IsTrue(expectedOrders.Any(), "expectedOrders is empty");

            var expectedUsers = new List<AppUser>
            {
                new AppUser { Id = "1", UserName = "Employee1" },

            };

            mockDbContext.Setup(x => x.Orders).ReturnsDbSet(expectedOrders);
            mockDbContext.Setup(x => x.ShoppingCartProducts).ReturnsDbSet(expectedShoppingCartProducts);
            mockDbContext.Setup(x => x.Products).ReturnsDbSet(expectedProducts);
            mockDbContext.Setup(x => x.ShoppingCarts).ReturnsDbSet(expectedShoppingCarts);

            mockUserManager.Setup(um => um.GetUsersInRoleAsync("Employee")).ReturnsAsync(expectedUsers);

            using var ctx = new Bunit.TestContext();
            ctx.Services.AddSingleton(mockDbContext.Object);
            ctx.Services.AddSingleton(mockUserManager.Object);
            ctx.Services.AddSingleton(mockRoleManager.Object);

            var cut = ctx.RenderComponent<AdminOrdersManagementComponent>();

            // Act

            await cut.InvokeAsync(() => cut.Instance.UpdateOrderStatus(expectedOrder, OrderStatusEnum.Confirmed));
            await cut.InvokeAsync(() => cut.Instance.AssignOrderToEmployeeAsync(expectedOrder, expectedUsers[0].Id));

            // Assert
            mockDbContext.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(2));
        }

    }
}
