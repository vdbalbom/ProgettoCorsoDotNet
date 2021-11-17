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
        public IActionResult Index()
        {
            List<Product> products = _service.Get().ToList();
            List<ProductViewModel> productViewModels = new();
            foreach (Product p in products)
            {
                productViewModels.Add(p.ToViewModel(_categoryService));
            }
            return View(productViewModels);
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
