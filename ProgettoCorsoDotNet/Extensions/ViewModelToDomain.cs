using Core.ProgettoCorsoDotNet.domain;
using Core.ProgettoCorsoDotNet.services.common;
using ProgettoCorsoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCorsoDotNet.Extensions
{
    public static class ViewModelToDomain
    {
        public static Product ToDomain(this ProductViewModel pvm)
        {
            Product product = new();
            product.CategoryID = pvm.CategoryID;
            product.Discontinued = pvm.Discontinued;
            product.Price = pvm.Price;
            product.ProductID = pvm.ProductID;
            product.ProductName = pvm.ProductName;
            product.UnitsInStock = pvm.UnitsInStock;
            return product;
        }

        public static Category ToDomain(this CategoryViewModel cvm)
        {
            Category category = new();
            category.CategoryID = cvm.CategoryID;
            category.CategoryName = cvm.CategoryName;
            category.Description = cvm.Description;
            return category;
        }
    }
}
