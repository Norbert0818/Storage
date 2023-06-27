using Moq;
using CoreBuisness;
using UseCases.UseCaseInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using StorageSystem.Pages.Components;

namespace MainApp.Tests
{
    [TestClass]
    public class CategoriesComponentTests
    {
        [TestMethod]
        public void CategoriesComponent_LoadCategories_DisplaysCategories()
        {
            // Arrange
            var viewCategoryUseCaseMock = new Mock<IViewCategoriesUseCase>();
            var deleteCategoryUseCaseMock = new Mock<IDeleteCategoryUseCase>();

            var expectedCategories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Test Category 1",
                    Description = "Test Description 1"
                },
                new Category
                {
                    Id = 2,
                    Name = "Test Category 2",
                    Description = "Test Description 2"
                }
                // Add more expected categories as needed
            };

            viewCategoryUseCaseMock.Setup(uc => uc.Execute()).Returns(expectedCategories);

            using var ctx = new Bunit.TestContext();
            ctx.Services.AddSingleton(viewCategoryUseCaseMock.Object);
            ctx.Services.AddSingleton(deleteCategoryUseCaseMock.Object);

            // Act
            var cut = ctx.RenderComponent<CategoriesComponent>();

            // Assert
            var categoriesRows = cut.FindAll("table tbody tr");
            Assert.AreEqual(expectedCategories.Count, categoriesRows.Count);
        }

        [TestMethod]
        public void CategoriesComponent_OnClickAddCategory_NavigatesToAddCategory()
        {
            // Arrange
            var viewCategoryUseCaseMock = new Mock<IViewCategoriesUseCase>();
            var deleteCategoryUseCaseMock = new Mock<IDeleteCategoryUseCase>();

            using var ctx = new Bunit.TestContext();
            ctx.Services.AddSingleton(viewCategoryUseCaseMock.Object);
            ctx.Services.AddSingleton(deleteCategoryUseCaseMock.Object);

            var cut = ctx.RenderComponent<CategoriesComponent>();

            // Act
            var addButton = cut.Find("button.btn-primary");
            addButton.Click();

            // Assert
            var expectedUri = "http://localhost/addcategory";
            var actualUri = ctx.Services.GetRequiredService<NavigationManager>().Uri;

            Assert.AreEqual(expectedUri, actualUri);
        }

        [TestMethod]
        public void CategoriesComponent_DeleteCategory_ReloadsCategories()
        {
            // Arrange
            var viewCategoryUseCaseMock = new Mock<IViewCategoriesUseCase>();
            var deleteCategoryUseCaseMock = new Mock<IDeleteCategoryUseCase>();

            var expectedCategories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Test Category",
                    Description = "Test Description"
                }
            };

            viewCategoryUseCaseMock.Setup(uc => uc.Execute()).Returns(expectedCategories);

            using var ctx = new Bunit.TestContext();
            ctx.Services.AddSingleton(viewCategoryUseCaseMock.Object);
            ctx.Services.AddSingleton(deleteCategoryUseCaseMock.Object);

            var cut = ctx.RenderComponent<CategoriesComponent>();

            // Act
            var deleteButton = cut.Find("button.btn-link");
            deleteButton.Click();

            // Assert
            deleteCategoryUseCaseMock.Verify(uc => uc.Delete(It.IsAny<int>()), Times.Once);
            viewCategoryUseCaseMock.Verify(uc => uc.Execute(), Times.Exactly(2));
        }
    }
}
