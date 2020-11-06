using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProductOrdersApi.Models;
using ProductOrdersApi.Services;

namespace ProductOrdersApi.Controllers
{
    [EnableCors("AllowCORS")]
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrdersService services;

        public OrdersController(IOrdersService ProductsServices)
        {
            this.services = ProductsServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orderItems = services.GetAllOrders();
            if (orderItems == null)
                return NotFound();

            return Ok(orderItems);
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<OrdersDto> orders)
        {
            var orderItems = services.AddOrders(orders);
            if (orderItems == null)
                return NotFound();

            return Ok(orderItems);
        }
    }
}
