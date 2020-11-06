using System;
using Xunit;
using ProductOrdersApi.Services;
using ProductOrdersApi.Models;
using ProductOrdersApi.Repositories;
using Moq;
using System.Collections.Generic;

namespace ProductAPITest
{
    public class OrdersServicesTests
    {
        private List<OrderItems> orderItems = new List<OrderItems>();
        private List<OrdersDto> orderSent = new List<OrdersDto>();
        private Mock<IOrdersRepository> orderRepositoryMock = new Mock<IOrdersRepository>();
        private Mock<IProductsRepository> productRepositoryMock = new Mock<IProductsRepository>();

        public OrdersServicesTests ()
        {
            orderItems = new List<OrderItems>()
            {
                {
                   new OrderItems() { Item = new Product() { Id = 2, Name = "Bread", Price = 2.00M }, Quantity = 200 }
                },
                {
                   new OrderItems() { Item = new Product() { Id = 3, Name = "Orange Juice", Price = 2.00M }, Quantity = 5 }
                }
            };

            orderSent = new List<OrdersDto>()
            {
                {
                   new OrdersDto() {ProductId = 2, Quantity = 200 }
                },
                {
                   new OrdersDto() { ProductId = 3, Quantity = 5  }
                }
            };


            orderRepositoryMock.Setup(x => x.AddOrders(It.IsAny<List<OrderItems>>())).Returns(orderItems);
            productRepositoryMock.Setup(x => x.GetProductsById(It.IsAny<int>())).Returns(new Product() { Id = 3, Name = "Orange Juice", Price = 2.00M });

        }

        [Fact]
        public void Should_return_the_correct_total_price_when_sending_of_orders()
        {          
           var service = new OrdersService(orderRepositoryMock.Object, productRepositoryMock.Object);
           var products = service.AddOrders(orderSent);

           Assert.True(products.TotalPrice == 410);
        }

        [Fact]
        public void Should_return_the_correct_total_price_per_line_when_sending_of_orders()
        {
            var service = new OrdersService(orderRepositoryMock.Object, productRepositoryMock.Object);
            var products = service.AddOrders(orderSent);

            Assert.True(products.Items[0].TotalPrice == 400);
            Assert.True(products.Items[1].TotalPrice == 10);


        }


        [Fact]
        public void Should_return_the_correct_products_per_line_when_sending_of_orders()
        {
            var service = new OrdersService(orderRepositoryMock.Object, productRepositoryMock.Object);
            var products = service.AddOrders(orderSent);

            Assert.True(products.Items[0].Item.Id == 3);
            Assert.True(products.Items[0].Item.Name == "Orange Juice");
            Assert.True(products.Items[0].Item.Price == 2);

            Assert.True(products.Items[1].Item.Id == 3);
            Assert.True(products.Items[1].Item.Name == "Orange Juice");
            Assert.True(products.Items[1].Item.Price == 2);

        }


        [Fact]
        public void Should_return_the_correct_quantyity_per_line_when_sending_of_orders()
        {
            var service = new OrdersService(orderRepositoryMock.Object, productRepositoryMock.Object);
            var products = service.AddOrders(orderSent);

            Assert.True(products.Items[0].Quantity == 200);
            Assert.True(products.Items[1].Quantity == 5);

        }






    }
}
