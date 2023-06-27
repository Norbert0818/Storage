using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBuisness;
using Microsoft.AspNetCore.Components;
using Moq;
using StorageSystem.Pages.Components;
using UseCases.UseCaseInterfaces;
using Xunit;

public class ProductsComponentTests
{
    [Fact]
    public void OnClickAddProduct_NavigatesToAddProductPage()
    {
        // Arrange
        var navigationManagerMock = new Mock<NavigationManager>();
        var component = new ProductsComponent(navigationManagerMock.Object, null, null, null);

        // Act
        component.OnClickAddProduct();

        // Assert
        navigationManagerMock.Verify(x => x.NavigateTo("/addproduct"), Times.Once);
    }

    [Fact]
    public void OnEditProduct_NavigatesToEditProductPage()
    {
        // Arrange
        var navigationManagerMock = new Mock<NavigationManager>();
        var component = new ProductsComponent(navigationManagerMock.Object, null, null, null);
        var product = new Product { Id = 1 };

        // Act
        component.OnEditProduct(product);

        // Assert
        navigationManagerMock.Verify(x => x.NavigateTo($"/editproduct/{product.Id}"), Times.Once);
    }

    [Fact]
    public void OnDeleteProduct_DeletesProduct()
    {
        // Arrange
        var productId = 1;
        var deleteProductUseCaseMock = new Mock<IDeleteProductUseCase>();
        var component = new ProductsComponent(null, null, null, deleteProductUseCaseMock.Object);

        // Act
        component.OnDeleteProduct(productId);

        // Assert
        deleteProductUseCaseMock.Verify(x => x.Execute(productId), Times.Once);
    }

    [Fact]
    public void OnInitialized_GetsProducts()
    {
        // Arrange
        var viewProductsUseCaseMock = new Mock<IViewProductsUseCase>();
        var products = new List<Product> { new Product(), new Product() };
        viewProductsUseCaseMock.Setup(x => x.Execute()).Returns(products);
        var component = new ProductsComponent(null, viewProductsUseCaseMock.Object, null, null);

        // Act
        component.OnInitialized();

        // Assert
        Assert.Equal(products, component.Products);
    }
}
