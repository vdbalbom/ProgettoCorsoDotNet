using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCorsoDotNet.Models
{
    public class ProductIndexViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public PaginationViewModel Pagination { get; set; }
    }
}
