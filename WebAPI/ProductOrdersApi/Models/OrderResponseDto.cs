using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductOrdersApi.Models
{
    public class OrderResponseDto
    {
        public List<OrderItems> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
