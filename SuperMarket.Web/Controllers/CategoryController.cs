using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Associate.DTO;
using SuperMarket.Business.Services.Abstract;

namespace SuperMarket.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService service;
        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryDTO model)
        {
            if (service.AddCategory(model))
            {
                TempData["Category"] = "Category Has Been Added";
                return View();
            }
            else
            {
                TempData["Category"] = "Something is wrong";
                return View(model);
            }
            
           
          
        }
    }
}
