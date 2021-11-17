using Core.ProgettoCorsoDotNet.domain;
using Core.ProgettoCorsoDotNet.persistence.common;
using Core.ProgettoCorsoDotNet.persistence.mock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ProgettoCorsoDotNet.persistence.mock
{
    public class ProductRepository : IRepository<Product>
    {
        public bool Delete(int id)
        {
            ProductDBInstance pdbi = DBMock.Products.FirstOrDefault(x => x.ProductID == id);
            if (pdbi == null) return false;
            DBMock.Products.Remove(pdbi);
            return true;
        }

        public IQueryable<Product> Get()
        {
            List<ProductDBInstance> productDBInstances = DBMock.Products;
            List<Product> products = new();
            foreach(ProductDBInstance pdbi in productDBInstances)
            {
                Product p = new();
                p.CategoryID = pdbi.CategoryID;
                p.Discontinued = pdbi.Discontinued;
                p.Price = pdbi.Price;
                p.ProductID = pdbi.ProductID;
                p.ProductName = pdbi.ProductName;
                p.UnitsInStock = pdbi.UnitsInStock;
                products.Add(p);
            }
            return products.AsQueryable();
        }

        public Product Insert(Product element)
        {
            element.ProductID = DBMock.Products.Count == 0 ? 1 : DBMock.Products.Max(x => x.ProductID) + 1;
            ProductDBInstance pdbi = new();
            pdbi.ProductID = element.ProductID;
            pdbi.ProductName = element.ProductName;
            pdbi.Discontinued = element.Discontinued;
            pdbi.CategoryID = element.CategoryID;
            pdbi.Price = element.Price;
            pdbi.UnitsInStock = element.UnitsInStock;
            DBMock.Products.Add(pdbi);
            return element;
        }

        public Product Update(Product element)
        {
            ProductDBInstance pdbi = DBMock.Products.FirstOrDefault(x => x.ProductID == element.ProductID);
            if (pdbi == null) return null;
            int index = DBMock.Products.IndexOf(pdbi);
            pdbi.ProductName = element.ProductName;
            pdbi.Discontinued = element.Discontinued;
            pdbi.CategoryID = element.CategoryID;
            pdbi.Price = element.Price;
            pdbi.UnitsInStock = element.UnitsInStock;
            DBMock.Products[index] = pdbi;
            return element;
        }
    }
}
