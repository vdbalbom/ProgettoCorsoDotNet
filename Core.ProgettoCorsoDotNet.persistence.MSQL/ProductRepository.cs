using Core.ProgettoCorsoDotNet.domain;
using Core.ProgettoCorsoDotNet.persistence.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ProgettoCorsoDotNet.persistence.MSQL
{
    public class ProductRepository : IRepository<Product>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> Get()
        {
            throw new NotImplementedException();
        }

        public Product Insert(Product element)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product element)
        {
            throw new NotImplementedException();
        }
    }
}
