using Core.ProgettoCorsoDotNet.domain;
using Core.ProgettoCorsoDotNet.persistence.common;
using Core.ProgettoCorsoDotNet.persistence.MSQL.EF.Data;
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
        public CategoryRepository(DbContext context)
        {
            _context = (NORTHWINDContext)context;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> Get()
        {
            throw new NotImplementedException();
        }

        public Category Insert(Category element)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category element)
        {
            throw new NotImplementedException();
        }
    }
}
