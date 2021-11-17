using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCorsoDotNet.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public bool Discontinued { get; set; }
        public decimal? Price { get; set; }
        public short? UnitsInStock { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
