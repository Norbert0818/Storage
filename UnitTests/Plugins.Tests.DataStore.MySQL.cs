using Moq;
using NUnit.Framework;
using Plugins.DataStore.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.Tests.DataStore.MySQL
{
	[TestFixture]
	public class ProductRepositoryTests
	{
		private Mock<DataContext> mockDataContext;
		private IProductRepository productRepository;

		[SetUp]
		public void SetUp()
		{
			mockDataContext = new Mock<DataContext>();
			productRepository = new ProductRepository(mockDataContext.Object);
		}

		[Test]
		public void AddProduct_ValidProduct_ProductAddedToDatabase()
		{
			// Arrange
			var product = new Product { Id = 1, Name = "Test Product", Price = 10.0 };

			// Act
			productRepository.AddProduct(product);

			// Assert
			mockDataContext.Verify(db => db.Products.Add(product), Times.Once);
			mockDataContext.Verify(db => db.SaveChanges(), Times.Once);
		}

		[Test]
		public void DeleteProduct_ExistingProductId_ProductRemovedFromDatabase()
		{
			// Arrange
			var productId = 1;
			var product = new Product { Id = productId, Name = "Test Product", Price = 10.0 };
			mockDataContext.Setup(db => db.Products.Find(productId)).Returns(product);

			// Act
			productRepository.DeleteProduct(productId);

			// Assert
			mockDataContext.Verify(db => db.Products.Remove(product), Times.Once);
			mockDataContext.Verify(db => db.SaveChanges(), Times.Once);
		}

		[Test]
		public void DeleteProduct_NonExistingProductId_NoActionTaken()
		{
			// Arrange
			var productId = 1;
			mockDataContext.Setup(db => db.Products.Find(productId)).Returns((Product)null);

			// Act
			productRepository.DeleteProduct(productId);

			// Assert
			mockDataContext.Verify(db => db.Products.Remove(It.IsAny<Product>()), Times.Never);
			mockDataContext.Verify(db => db.SaveChanges(), Times.Never);
		}

		[Test]
		public void GetProductById_ExistingProductId_ReturnsProduct()
		{
			// Arrange
			var productId = 1;
			var product = new Product { Id = productId, Name = "Test Product", Price = 10.0 };
			mockDataContext.Setup(db => db.Products.Find(productId)).Returns(product);

			// Act
			var result = productRepository.GetProductById(productId);

			// Assert
			Assert.AreEqual(product, result);
		}

		[Test]
		public void GetProductById_NonExistingProductId_ReturnsNull()
		{
			// Arrange
			var productId = 1;
			mockDataContext.Setup(db => db.Products.Find(productId)).Returns((Product)null);

			// Act
			var result = productRepository.GetProductById(productId);

			// Assert
			Assert.IsNull(result);
		}

		[Test]
		public void GetProducts_ReturnsAllProducts()
		{
			// Arrange
			var products = new List<Product>
			{
				new Product { Id = 1, Name = "Product 1", Price = 10.0 },
				new Product { Id = 2, Name = "Product 2", Price = 20.0 }
			};
			mockDataContext.Setup(db => db.Products.ToList()).Returns(products);

			// Act
			var result = productRepository.GetProducts();

			// Assert
			CollectionAssert.AreEqual(products, result);
		}

		[Test]
		public void GetProductsByCategoryId_ValidCategoryId_ReturnsProductsInCategory()
		{
			// Arrange
			var categoryId = 1;
			var products = new List<Product>
			{
				new Product { Id = 1, Name = "Product 1", Price = 10.0, CategoryId = categoryId },
				new Product { Id = 2, Name = "Product 2", Price = 20.0, CategoryId = categoryId },
				new Product { Id = 3, Name = "Product 3", Price = 30.0, CategoryId = 2 }
			};
			mockDataContext.Setup(db => db.Products.Where(p => p.CategoryId == categoryId).ToList()).Returns(products);

			// Act
			var result = productRepository.GetProductsByCategoryId(categoryId);

			// Assert
			CollectionAssert.AreEqual(products, result);
		}

		[Test]
		public void UpdateProduct_ValidProduct_ProductUpdatedInDatabase()
		{
			// Arrange
			var product = new Product { Id = 1, Name = "Updated Product", Price = 15.0 };
			var existingProduct = new Product { Id = 1, Name = "Existing Product", Price = 10.0 };
			mockDataContext.Setup(db => db.Products.Find(product.Id)).Returns(existingProduct);

			// Act
			productRepository.UpdateProduct(product);

			// Assert
			Assert.AreEqual(product.Name, existingProduct.Name);
			Assert.AreEqual(product.Price, existingProduct.Price);
			mockDataContext.Verify(db => db.SaveChanges(), Times.Once);
		}
	}
}
