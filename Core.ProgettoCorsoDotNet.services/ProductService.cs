using Core.ProgettoCorsoDotNet.domain;
using Core.ProgettoCorsoDotNet.persistence.common;
using Core.ProgettoCorsoDotNet.services.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ProgettoCorsoDotNet.services
{
    public class ProductService : IService<Product>
    {
        private IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IQueryable<Product> Get()
        {
            return _repository.Get();
        }

        public Product GetByID(int id)
        {
            if (id == 0) return new();
            return _repository.Get().FirstOrDefault(x => x.ProductID == id);
        }

        public Product Save(Product element)
        {
            if (element.ProductID == 0)
            {
                return _repository.Insert(element);
            }
            else
            {
                return _repository.Update(element);
            }
            
        }

    }
}
