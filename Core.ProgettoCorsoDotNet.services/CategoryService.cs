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
    public class CategoryService : IService<Category>
    {
        private IRepository<Category> _repository;
        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IQueryable<Category> Get()
        {
            return _repository.Get();
        }

        public Category GetByID(int id)
        {
            if (id == 0) return new();
            return _repository.Get().FirstOrDefault(x => x.CategoryID == id);
        }
        public Category Save(Category element)
        {
            if (element.CategoryID == 0)
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
