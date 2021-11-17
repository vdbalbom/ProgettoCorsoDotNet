using Core.ProgettoCorsoDotNet.domain;
using Core.ProgettoCorsoDotNet.persistence.MSQL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ProgettoCorsoDotNet.persistence.MSQL.Extensions
{
    public static class Extensions
    {
        internal static IQueryable<Product> ProjectToDomain(this IQueryable<Products> query)
        {
            return query.Select(x => new Product()
            {
                CategoryID = (int)x.CategoryId,
                ProductID = x.ProductId,
                Discontinued = x.Discontinued,
                Price = x.UnitPrice,
                ProductName = x.ProductName,
                UnitsInStock = x.UnitsInStock
            });
        }
        internal static IQueryable<Category> ProjectToDomain(this IQueryable<Categories> query)
        {
            return query.Select(x => new Category()
            {
                CategoryID = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description
            });
        }

        internal static Product ProjectToDomain(this Products model)
        {
            return  new Product()
            {
                CategoryID = (int)model.CategoryId,
                ProductID = model.ProductId,
                Discontinued = model.Discontinued,
                Price = model.UnitPrice,
                ProductName = model.ProductName,
                UnitsInStock = model.UnitsInStock
            };
        }
        internal static Category ProjectToDomain(this Categories model)
        {
            return  new Category()
            {
                CategoryID = model.CategoryId,
                CategoryName = model.CategoryName,
                Description = model.Description
            };
        }

        internal static Products ProjectToModel(this Product domain)
        {
            return new Products()
            {
                CategoryId = domain.CategoryID,
                ProductId = domain.ProductID,
                Discontinued = domain.Discontinued,
                UnitPrice = domain.Price,
                ProductName = domain.ProductName,
                UnitsInStock = domain.UnitsInStock
            };
        }
        internal static Categories ProjectToModel(this Category domain)
        {
            return new Categories()
            {
                CategoryId = domain.CategoryID,
                CategoryName = domain.CategoryName,
                Description = domain.Description
            };
        }
    }
}
