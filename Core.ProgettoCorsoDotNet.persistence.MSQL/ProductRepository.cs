using Core.ProgettoCorsoDotNet.domain;
using Core.ProgettoCorsoDotNet.persistence.common;
using Core.ProgettoCorsoDotNet.persistence.MSQL.EF.Data;
using Core.ProgettoCorsoDotNet.persistence.MSQL.EF.Models;
using Core.ProgettoCorsoDotNet.persistence.MSQL.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ProgettoCorsoDotNet.persistence.MSQL
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly NORTHWINDContext _context;
        public ProductRepository(NORTHWINDContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            Products element = _context.Products.FirstOrDefault(x => x.ProductId == id);
            _ = _context.Products.Remove(element);
            _= _context.SaveChanges();
            return true;
        }

        public IQueryable<Product> Get()
        {
            return _context.Products.AsQueryable().ProjectToDomain();
        }

        public Product Insert(Product element)
        {
            int id = _context.Products.Add(element.ProjectToModel()).Entity.ProductId;
            _ = _context.SaveChanges();
            element.CategoryID = id;
            return element;
        }

        public Product Update(Product element)
        {
            _context.Products.Update(element.ProjectToModel());
            _ = _context.SaveChanges();
            return element;
        }
    }
}
