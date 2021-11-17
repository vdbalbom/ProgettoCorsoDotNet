using Core.ProgettoCorsoDotNet.services.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ProgettoCorsoDotNet.domain
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public bool Discontinued { get; set; }
        public decimal? Price { get; set; }
        public short? UnitsInStock { get; set; }

        public Category GetCategory(IService<Category> categoryService)
        {
            return categoryService.GetByID(CategoryID);
        }

        public void SetCategory(Category category)
        {
            CategoryID = category.CategoryID;
        }
    }
}
