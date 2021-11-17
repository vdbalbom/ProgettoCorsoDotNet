using Core.ProgettoCorsoDotNet.persistence.mock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ProgettoCorsoDotNet.persistence.mock
{
    public static class DBMock
    {
        private static List<CategoryDBInstance> _categories;
        private static List<ProductDBInstance> _products;

        public static List<CategoryDBInstance> Categories
        { 
            get 
            {
                if (_categories == null) _categories = new();
                return _categories; 
            } 
        }
        public static List<ProductDBInstance> Products 
        { 
            get 
            {
                if (_products == null) _products = new();
                return _products; 
            } 
        }
    }
}
