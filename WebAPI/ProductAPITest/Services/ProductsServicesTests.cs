using System;
using Xunit;
using ProductOrdersApi.Services;
using ProductOrdersApi.Models;
using ProductOrdersApi.Repositories;
using Moq;
using System.Collections.Generic;

namespace ProductAPITest
{
    public class ProductsServicesTests
    {

        [Fact]
        public void Should_return_initial_value_of_products()
        {

           var repositoryMock = new Mock<IProductsRepository>();
            repositoryMock.Setup(x => x.GetAllProducts()).Returns(new List<Product>() {
                {
                    new Product() { Id = 1, Name = "Cookies", Price = 2.99M }
                },
                {
                    new Product() { Id = 2, Name = "Bread", Price = 2.00M }
                },
                {
                    new Product() { Id = 3, Name = "Orange Juice", Price = 5.00M }
                },
             });
           var service = new ProductsService(repositoryMock.Object);

           var products = service.GetAllProducts();

           Assert.True(products[0].Name == "Cookies");
           Assert.True(products[1].Name == "Bread");
           Assert.True(products[2].Name == "Orange Juice");
        }




        [Fact]
        public void After_adding_new_product_it_should_be_included_together_in_the_product_list()
        {

            var repositoryMock = new Mock<IProductsRepository>();
            repositoryMock.Setup(x => x.CreateProduct(It.IsAny<Product>()))
                .Returns(new Product() { Name = "Orange Juice", Price = 5.00M });

            var service = new ProductsService(repositoryMock.Object);

            var product = service.CreateProduct(It.IsAny<Product>());

            Assert.True(product.Name == "Orange Juice");
            Assert.True(product.Price == "$5.00");

        }


        [Fact]
        public void Should_return_the_product_selected()
        {

            var repositoryMock = new Mock<IProductsRepository>();
            repositoryMock.Setup(x => x.GetProductsById(1))
                .Returns(new Product() { Id = 1, Name = "Orange Juice", Price = 5.00M });

            var service = new ProductsService(repositoryMock.Object);

            var product = service.GetProductsById(1);

            Assert.True(product.Id == 1);
            Assert.True(product.Name == "Orange Juice");
            Assert.True(product.Price == "$5.00");

        }
    }
}
