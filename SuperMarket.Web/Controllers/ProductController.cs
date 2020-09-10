using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Associate.DTO;
using SuperMarket.Associate.VM;
using SuperMarket.Business.Services.Abstract;

namespace SuperMarket.Web.Controllers
{
    public class ProductController : Controller
    {
        int pageSize = 9;
        private readonly IProductService service;
        private readonly ICategoryService catService;
        public ProductController(IProductService service, ICategoryService catService)
        {
            this.service = service;
            this.catService = catService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ProductCategoryVM model = new ProductCategoryVM();
            model.Categories = catService.GetCategories();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ProductCategoryVM model)
        {
            if (service.AddProduct(model.Product))
            {
                ViewBag.Success = "Product Has Been Added";
            }
            else
            {
                ViewBag.Success = "Something is wrong";
            }
            model.Categories = catService.GetCategories();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return View(service.Get(Id));
        }

        [HttpPost]
        public IActionResult Edit(ProductDTO model)
        {
            if (service.EditProduct(model))
            {
                ViewBag.Success = "Product has been updated";
            }
            else
            {
                ViewBag.Success = "Product has been wrong";
                
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult List(int? sayfano)
        {
            IList<ProductDTO> model = service.GetProductList(sayfano, pageSize);
            bool isAjax = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                return PartialView("_ProductListPartial", model);
            }
            return View(model);
        }

        public IActionResult Delete(int Id)
        {
            if (service.DeleteProduct(Id))
            {
                return new JsonResult("1");
            }
            else
            {
                return new JsonResult("-1");
            }
        }

        public IActionResult Detail(int Id)
        {
            return View(service.Get(Id));
        }
        
    }
}
