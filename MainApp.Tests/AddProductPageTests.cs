using Moq;
using CoreBuisness;
using UseCases.UseCaseInterfaces;
using StorageSystem.Pages.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace MainApp.Tests
{
    [TestClass]
    public class AddProductPageTests
    {
        [TestMethod]
        public void AddProductPage_ValidProduct_SubmitsProductAndNavigates()
        {
            // Arrange
            var addProductUseCaseMock = new Mock<IAddProductUseCase>();
            var viewCategoriesUseCaseMock = new Mock<IViewCategoriesUseCase>();

            var expectedProduct = new Product
            {
                Name = "Test Product",
                CategoryId = 1,
                Price = 9.99,
                MaxQuantity = 10,
                ImageLink = "https://example.com/image.jpg",
                Description = "Test description"
            };

            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Category 1" },
                new Category { Id = 2, Name = "Category 2" }
            };

            viewCategoriesUseCaseMock.Setup(uc => uc.Execute())
                .Returns(categories);

            using var ctx = new Bunit.TestContext();
            ctx.Services.AddSingleton(addProductUseCaseMock.Object);
            ctx.Services.AddSingleton(viewCategoriesUseCaseMock.Object);

            var cut = ctx.RenderComponent<AddProductComponent>();

            var nameInput = cut.Find("#name");
            nameInput.Change("Test Product");

            var categorySelect = cut.Find("#category");
            categorySelect.Change(1);

            var priceInput = cut.Find("#price");
            priceInput.Change("9.99");

            var quantityInput = cut.Find("#qty");
            quantityInput.Change("10");

            var imageInput = cut.Find("#product-image");
            imageInput.Change("https://example.com/image.jpg");

            var descriptionInput = cut.Find("#product-description");
            descriptionInput.Change("Test description");

            // Act
            var saveButton = cut.Find("button[type='submit']");
            saveButton.Click();

            // Assert
            addProductUseCaseMock.Verify(uc => uc.Execute(It.Is<Product>(p =>
                p.Name == expectedProduct.Name &&
                p.CategoryId == expectedProduct.CategoryId &&
                p.Price == expectedProduct.Price &&
                p.MaxQuantity == expectedProduct.MaxQuantity &&
                p.ImageLink == expectedProduct.ImageLink &&
                p.Description == expectedProduct.Description
            )), Times.Once);

            var expectedUri = "http://localhost/editingproducts";
            var actualUri = ctx.Services.GetRequiredService<NavigationManager>().Uri;

            Console.WriteLine("Expected URI: " + expectedUri);
            Console.WriteLine("Actual URI: " + actualUri);

            Assert.IsTrue(string.Equals(expectedUri, actualUri, StringComparison.OrdinalIgnoreCase));




        }
    }
}
