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
    public class OrderController : Controller
    {

        private readonly IOrderService orderService;
        private readonly ICartItemService cartItemService;
        private readonly IAppUserService appUserService;
        public OrderController(IOrderService orderService, ICartItemService cartItemService, IAppUserService appUserService)
        {
            this.appUserService = appUserService;
            this.orderService = orderService;
            this.cartItemService = cartItemService;

        }

        [HttpGet]
        public IActionResult Add(int Id)
        {
            OrderCartItemVM model = new OrderCartItemVM();
            model.CartItems = cartItemService.GetCartItems(Id);
            TempData["totalAmount"] = cartItemService.GetTotalAmount(Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(OrderCartItemVM model)
        {
            var currentUserName = HttpContext.Session.GetString("currentUser");
            AppUser currentUser = appUserService.getUser(currentUserName);
            if (orderService.AddOrder(model.Order, currentUser.Id))
            {
                return RedirectToAction("SiparisOnay");
            }
            else
            {
                ViewBag.Siparis = "Siparis Oluşturulurken Hata Meydana Geldi!";
                model.CartItems = cartItemService.GetCartItems(currentUser.Id);
                TempData["totalAmount"] = cartItemService.GetTotalAmount(currentUser.Id);
            }
            return View(model);
        }

        public IActionResult GetOrders()
        {
            var currentUserName = HttpContext.Session.GetString("currentUser");
            AppUser currentUser = appUserService.getUser(currentUserName);
            return View(orderService.GetOrders(currentUser.Id));
        }

        
        public IActionResult GetOrder(int orderId)
        {
            return new JsonResult(orderService.GetOrder(orderId));
        }




        [HttpGet]
        public IActionResult SiparisOnay()
        {

            return View();
        }
    }
}
