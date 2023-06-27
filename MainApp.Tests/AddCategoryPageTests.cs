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
    public class AddCategoryPageTests
    {
        [TestMethod]
        public void AddCategoryPage_ValidCategory_SubmitsCategoryAndNavigates()
        {
            // Arrange
            var addCategoryUseCaseMock = new Mock<IAddCategoryUseCase>();

            var expectedCategory = new Category
            {
                Name = "Test Category",
                Description = "Test Description"
            };

            using var ctx = new Bunit.TestContext();
            ctx.Services.AddSingleton(addCategoryUseCaseMock.Object);

            var cut = ctx.RenderComponent<AddCategoryComponent>();

            var nameInput = cut.Find("#name");
            nameInput.Change("Test Category");

            var descriptionInput = cut.Find("#description");
            descriptionInput.Change("Test Description");

            // Act
            var saveButton = cut.Find("button[type='submit']");
            saveButton.Click();

            // Assert
            addCategoryUseCaseMock.Verify(uc => uc.Execute(It.Is<Category>(c =>
                c.Name == expectedCategory.Name &&
                c.Description == expectedCategory.Description
            )), Times.Once);

            var expectedUri = "http://localhost/categories";
            var actualUri = ctx.Services.GetRequiredService<NavigationManager>().Uri;

            Console.WriteLine("Expected URI: " + expectedUri);
            Console.WriteLine("Actual URI: " + actualUri);

            Assert.IsTrue(string.Equals(expectedUri, actualUri, StringComparison.OrdinalIgnoreCase));
        }
    }
}
