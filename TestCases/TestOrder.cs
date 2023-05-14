using Bunit;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

public class OrderCreationTests : TestContext
{
    [Fact]
    public void LoggedInUser_CanCreateOrder()
    {
        // Arrange
        var authServiceMock = new Mock<AuthenticationStateProvider>();
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, "John Doe"),
            // Add any additional claims as necessary
        }));

        authServiceMock.Setup(auth => auth.GetAuthenticationStateAsync())
            .ReturnsAsync(new AuthenticationState(user));

        Services.AddSingleton(authServiceMock.Object);

        var cut = RenderComponent<OrderComponent>();

        // Act
        cut.Find("button.create-order").Click();

        // Assert
        var orderCreated = cut.Find("div.order-created");
        Assert.NotNull(orderCreated);
        Assert.Equal("Order created successfully!", orderCreated.TextContent);
    }
}