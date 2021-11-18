using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgettoCorsoDotNet.Models;
using Core.ProgettoCorsoDotNet.domain;
using Core.ProgettoCorsoDotNet.services.common;
using ProgettoCorsoDotNet.Extensions;

namespace ProgettoCorsoDotNet.Controllers
{
    public class CategoryController : Controller
    {
        IService<Category> _service;
        IService<Product> _productService;
        public CategoryController(IService<Category> service, IService<Product> productService)
        {
            _service = service;
            _productService = productService;
        }
        public IActionResult Index()
        {
            List<Category> categories = _service.Get().ToList();
            List<CategoryViewModel> categorieViewModels = new();
            foreach(Category c in categories)
            {
                categorieViewModels.Add(c.ToViewModel(_productService));
            }
            return View(categorieViewModels);
        }

        [HttpGet]
        public IActionResult Category(int id)
        {
            return View(_service.GetByID(id).ToViewModel(_productService));
        }

        [HttpPost]
        public IActionResult Category(CategoryViewModel model)
        {
            Category category = null;
            if (ModelState.IsValid)
            {
                category = _service.Save(model.ToDomain());
            }
            if (category == null) return View(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (_service.GetByID(id).CanDelete(_productService))
            {
                _ = _service.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
