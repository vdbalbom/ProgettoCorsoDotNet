using Core.ProgettoCorsoDotNet.domain;
using Core.ProgettoCorsoDotNet.services.common;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProgettoCorsoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCorsoDotNet.Extensions
{
    public static class Extensions
    {
        internal static Product ToDomain(this ProductViewModel pvm)
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

        internal static Category ToDomain(this CategoryViewModel cvm)
        {
            Category category = new();
            category.CategoryID = cvm.CategoryID;
            category.CategoryName = cvm.CategoryName;
            category.Description = cvm.Description;
            return category;
        }

        internal static ProductViewModel ToViewModel(this Product product, IService<Category> categoryService, bool withcategoryList = false)
        {
            ProductViewModel pvm = new();
            pvm.CategoryID = product.GetCategory(categoryService).CategoryID;
            pvm.CategoryName = product.GetCategory(categoryService).CategoryName;
            pvm.Discontinued = product.Discontinued;
            pvm.Price = product.Price;
            pvm.ProductID = product.ProductID;
            pvm.ProductName = product.ProductName;
            pvm.UnitsInStock = product.UnitsInStock;
            pvm.Categories = null;
            if (withcategoryList)
            {
                pvm.Categories = new();
                foreach (Category cat in categoryService.Get())
                {
                    SelectListItem item = new();
                    item.Selected = cat.CategoryID == pvm.CategoryID;
                    item.Text = cat.CategoryName;
                    item.Value = cat.CategoryID.ToString();
                    pvm.Categories.Add(item);
                }
            }
            return pvm;
        }

        internal static CategoryViewModel ToViewModel(this Category category)
        {
            CategoryViewModel cvm = new();
            cvm.CategoryID = category.CategoryID;
            cvm.CategoryName = category.CategoryName;
            cvm.Description = category.Description;
            return cvm;
        }
    }
}
