using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductOrdersApi.Models
{
    public class OrdersDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
