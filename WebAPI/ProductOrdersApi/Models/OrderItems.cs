﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductOrdersApi.Models
{
    public class OrderItems
    {
        public Product Item { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
