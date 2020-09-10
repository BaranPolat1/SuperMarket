using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Associate.DTO;
using SuperMarket.Business.Services.Abstract;
using SuperMarket.Entity.Entities;

namespace SuperMarket.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService service;
        private readonly IAppUserService userService;
        private readonly ICartItemService cartItemService;
        public CartController(ICartService service, IAppUserService userService, ICartItemService cartItemService)
        {
            this.service = service;
            this.userService = userService;
            this.cartItemService = cartItemService;
        }
        
        [HttpGet]
        public IActionResult GetCart()
        {
            var currentUserName = HttpContext.Session.GetString("currentUser");
            AppUser user = userService.getUser(currentUserName);
            CartDTO model = service.GetCart(user.Id);
            ViewBag.TotalAmount = cartItemService.GetTotalAmount(user.Id);
            return View(model);
        }
    }
}
