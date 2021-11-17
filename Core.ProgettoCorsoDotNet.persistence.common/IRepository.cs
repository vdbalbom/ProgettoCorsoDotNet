using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ProgettoCorsoDotNet.persistence.common
{
    public interface IRepository<T>
    {
        public IQueryable<T> Get();
        public T Insert(T element);
        public T Update(T element);
        public bool Delete(int id);
    }
}