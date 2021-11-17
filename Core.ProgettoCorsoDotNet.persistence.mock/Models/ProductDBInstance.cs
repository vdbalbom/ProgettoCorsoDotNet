﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ProgettoCorsoDotNet.persistence.mock.Models
{
    public class ProductDBInstance
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public bool Discontinued { get; set; }
        public decimal? Price { get; set; }
        public short? UnitsInStock { get; set; }
    }
}
