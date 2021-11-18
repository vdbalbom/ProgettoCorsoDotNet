using Core.ProgettoCorsoDotNet.services.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ProgettoCorsoDotNet.domain
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        
        public bool CanDelete(IService<Product> productService)
        {
            if(productService.Get().Where(x => x.CategoryID == CategoryID).Count() == 0)
            {
                return true;
            }
            return false;
        }
    }
}
