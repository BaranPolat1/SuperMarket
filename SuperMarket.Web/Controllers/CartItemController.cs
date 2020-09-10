using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Associate.VM;
using SuperMarket.Business.Services.Abstract;
using SuperMarket.Entity.Entities;

namespace SuperMarket.Web.Controllers
{
    public class CartItemController : Controller
    {
        private readonly ICartItemService service;
        private readonly IAppUserService userService;

        public CartItemController(ICartItemService service, IAppUserService userService)
        {
            this.service = service;
            this.userService = userService;

        }

        [HttpPost]
        public IActionResult Add(string productId, string price)
        {
            string currentUserName = HttpContext.Session.GetString("currentUser");
            AppUser currentUser = userService.getUser(currentUserName);
            return new JsonResult(service.AddCartItem(currentUser.Id, int.Parse(productId), price));

        }

        public IActionResult Delete(string productId, string quantity,string type)
        {
            string currentUserName = HttpContext.Session.GetString("currentUser");
            AppUser currentUser = userService.getUser(currentUserName);
            return new JsonResult(service.DeleteCartItem(currentUser.Id, int.Parse(productId), int.Parse(quantity),type));

        }

        public IActionResult Deneme()
        {
            JsonCartItemVM model = new JsonCartItemVM();
            model.price = 2;
            return new JsonResult(model);

        }
    }
}
