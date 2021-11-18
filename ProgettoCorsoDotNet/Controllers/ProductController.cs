using Core.ProgettoCorsoDotNet.domain;
using Core.ProgettoCorsoDotNet.services.common;
using Microsoft.AspNetCore.Mvc;
using ProgettoCorsoDotNet.Models;
using ProgettoCorsoDotNet.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCorsoDotNet.Controllers
{
    public class ProductController : Controller
    {
        IService<Product> _service;
        IService<Category> _categoryService;
        public ProductController(IService<Product> service, IService<Category> categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }
        public IActionResult Index(int page = 0, int perPage = 10)
        {
            ProductIndexViewModel model = new();
            model.Products = new();
            List<Product> products = _service.Get().Skip(perPage*page).Take(perPage).ToList();
            foreach (Product p in products)
            {
                model.Products.Add(p.ToViewModel(_categoryService));
            }
            model.Pagination = new(page, perPage, _service.Get().Count());
            return View(model);
        }

        [HttpGet]
        public IActionResult Product(int id)
        {
            return View(_service.GetByID(id).ToViewModel(_categoryService, true));
        }

        [HttpPost]
        public IActionResult Product(ProductViewModel model)
        {
            Product p;
            if (ModelState.IsValid)
            {
                p = model.ToDomain();
                _service.Save(p);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _ = _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
