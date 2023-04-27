using CoreBuisness;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class ViewProductsUseCase : IViewProductsUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewProductsUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> Execute()
        {
            return productRepository.GetProducts();
        }

        //public List<KeyValuePair<Product, int>> ConvertCartProductsToProducts(List<Product> cartProducts)
        //{
        //    List<KeyValuePair<Product, int>> products = new List<KeyValuePair<Product, int>>();
        //    foreach (var cartProduct in cartProducts)
        //    {
        //        products.Add(new KeyValuePair<Product, int>(productRepository.GetProductById(cartProduct.Id), cartProduct.Quantity));
        //    }

        //    return products;
        //}
    }
}
