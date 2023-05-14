using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

public class ProductCrudTests : TestContext
{
    [Fact]
    public void Product_CRUD_Operations()
    {
        // Arrange
        var productServiceMock = new Mock<IProductService>();
        Services.AddSingleton(productServiceMock.Object);

        var cut = RenderComponent<ProductComponent>();

        // Act - Create
        cut.Find("#create-product").Click();
        cut.Find("#product-name").Change("New Product");
        cut.Find("#product-price").Change("10.99");
        cut.Find("#save-product").Click();

        // Assert - Create
        productServiceMock.Verify(service => service.CreateProduct(It.Is<Product>(p =>
            p.Name == "New Product" &&
            p.Price == 10.99
        )));

        // Act - Read
        cut.Find("#load-products").Click();

        // Assert - Read
        var products = cut.FindAll(".product-item");
        Assert.Equal(1, products.Count);

        // Act - Update
        cut.Find(".edit-product").Click();
        cut.Find("#product-name").Change("Updated Product");
        cut.Find("#product-price").Change("15.99");
        cut.Find("#save-product").Click();

        // Assert - Update
        productServiceMock.Verify(service => service.UpdateProduct(It.Is<Product>(p =>
            p.Name == "Updated Product" &&
            p.Price == 15.99
        )));

        // Act - Delete
        cut.Find(".delete-product").Click();

        // Assert - Delete
        productServiceMock.Verify(service => service.DeleteProduct(It.IsAny<int>()));
    }
}
