﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class ProductType
    {
        public long ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public long Code { get; set; }
        public string Symbol { get; set; }
        public string  Description { get; set; }
        public bool Enabled { get; set; }
    }
}
