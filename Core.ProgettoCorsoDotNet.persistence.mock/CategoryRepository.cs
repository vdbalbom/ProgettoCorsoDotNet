using Core.ProgettoCorsoDotNet.domain;
using Core.ProgettoCorsoDotNet.persistence.common;
using Core.ProgettoCorsoDotNet.persistence.mock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ProgettoCorsoDotNet.persistence.mock
{
    public class CategoryRepository : IRepository<Category>
    {
        public bool Delete(int id)
        {
            CategoryDBInstance cdbi = DBMock.Categories.FirstOrDefault(x => x.CategoryID == id);
            if (cdbi == null) return false;
            DBMock.Categories.Remove(cdbi);
            return true;
        }

        public IQueryable<Category> Get()
        {

            List<CategoryDBInstance> categoryDBInstances = DBMock.Categories;
            List<Category> categories = new();
            foreach(CategoryDBInstance cdbi in categoryDBInstances)
            {
                Category c = new();
                c.CategoryID = cdbi.CategoryID;
                c.CategoryName = cdbi.CategoryName;
                c.Description = cdbi.Description;
                categories.Add(c);
            }
            return categories.AsQueryable();
        }

        public Category Insert(Category element)
        {
            element.CategoryID = DBMock.Categories.Count == 0 ? 1 : DBMock.Categories.Max(x => x.CategoryID) + 1;
            CategoryDBInstance cdbi = new();
            cdbi.CategoryID = element.CategoryID;
            cdbi.CategoryName = element.CategoryName;
            cdbi.Description = element.Description;
            DBMock.Categories.Add(cdbi);
            return element;
        }

        public Category Update(Category element)
        {
            CategoryDBInstance cdbi = DBMock.Categories.FirstOrDefault(x => x.CategoryID == element.CategoryID);
            if (cdbi == null) return null;
            int index = DBMock.Categories.IndexOf(cdbi);
            cdbi.CategoryName = element.CategoryName;
            cdbi.Description = element.Description;
            DBMock.Categories[index] = cdbi;
            return element;
        }
    }
}
