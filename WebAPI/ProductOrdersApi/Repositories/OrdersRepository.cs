using Microsoft.Extensions.Caching.Memory;
using ProductOrdersApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductOrdersApi.Repositories
{

    public interface IOrdersRepository
    {
        public List<OrderItems> GetAllOrders();
        public List<OrderItems> AddOrders(List<OrderItems> orders);
    }

    public class OrdersRepository: IOrdersRepository
    {

        private IMemoryCache orderCache;

        public OrdersRepository(IMemoryCache cache)
        {
            this.orderCache = cache;

        }

   
        public List<OrderItems> GetAllOrders()
        {
            var orders = new List<OrderItems>();
            orderCache.TryGetValue("OrderList", out orders);
            return orders;
        }


        public List<OrderItems> AddOrders(List<OrderItems> orders)
        {
            var orderList = new List<OrderItems>();
            orderCache.TryGetValue("OrderList", out orderList);

            if(orderList == null)
            {
                orderCache.Set("OrderList", orders);
            }else
            {
                var newOrderList = orderList.Concat(orders);
                orderCache.Set("OrderList", orders);
            }
     
            return orders;
        }


    }
}
