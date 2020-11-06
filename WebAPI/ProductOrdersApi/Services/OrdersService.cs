using ProductOrdersApi.Models;
using ProductOrdersApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductOrdersApi.Services
{

    public interface IOrdersService
    {
        public List<OrderItems> GetAllOrders();
        public OrderResponseDto AddOrders(List<OrdersDto> orders);
    }
    public class OrdersService: IOrdersService
    {
        private IOrdersRepository orderRepository;
        private IProductsRepository productRepository;

        public OrdersService(IOrdersRepository ordersRepository, IProductsRepository productRepository)
        {
            this.orderRepository = ordersRepository;
            this.productRepository = productRepository;
        }

        public OrderResponseDto AddOrders(List<OrdersDto> orders)
        {
            var orderItems = this.MapToOrderItems(orders);
            this.orderRepository.AddOrders(orderItems.Items);

            return new OrderResponseDto()
            {
                Items = orderItems.Items,
                TotalPrice = orderItems.TotalPrice
            };
        }

        public List<OrderItems> GetAllOrders() => this.orderRepository.GetAllOrders();
        

        private (List<OrderItems> Items, decimal TotalPrice) MapToOrderItems(List<OrdersDto> orders)
        {
            var orderItems = new List<OrderItems>();
            var totalPrice = 0.0M;
            orders.ForEach(item =>
            {
                var product = this.productRepository.GetProductsById(item.ProductId);
                orderItems.Add(new OrderItems()
                {
                    Item = product,
                    Quantity = item.Quantity,
                    TotalPrice = item.Quantity * product.Price

                });

                totalPrice = totalPrice + (item.Quantity * product.Price);
            });

            return (orderItems, totalPrice);
        }
    }
}
