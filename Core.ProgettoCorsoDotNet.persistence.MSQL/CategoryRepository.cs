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
    public class CategoryRepository : IRepository<Category>
    {
        private readonly NORTHWINDContext _context;
        public CategoryRepository(NORTHWINDContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            Categories element = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            _ = _context.Categories.Remove(element);
            _ = _context.SaveChanges();
            return true;
        }

        public IQueryable<Category> Get()
        {
            return _context.Categories.AsQueryable().ProjectToDomain();
        }

        public Category Insert(Category element)
        {
            int id = _context.Categories.Add(element.ProjectToModel()).Entity.CategoryId;
            _ = _context.SaveChanges();
            element.CategoryID = id;
            return element;
        }

        public Category Update(Category element)
        {
            _context.Update(element.ProjectToModel());
            _ = _context.SaveChanges();
            return element;
        }
    }
}
