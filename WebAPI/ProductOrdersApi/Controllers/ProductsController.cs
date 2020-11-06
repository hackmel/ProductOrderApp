using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductOrdersApi.Services;
using ProductOrdersApi.Models;

namespace ProductOrdersApi.Controllers
{
    [EnableCors("AllowCORS")]
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductsService services;

        public ProductsController(IProductsService ProductsServices)
        {
            this.services = ProductsServices;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int Id)
        {
            var product = services.GetProductsById(Id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = services.GetAllProducts();
            if (products == null)
                return NotFound();

            return Ok(products);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            var products = services.CreateProduct(product);
            if (products == null)
                return NotFound();

            return Ok(products);
        }
    }
}
