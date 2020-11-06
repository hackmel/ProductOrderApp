using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductOrdersApi.Models
{
    public class ProductsResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
