﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz
{
    public class Product : IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Price:C}";
        }
    }
}
