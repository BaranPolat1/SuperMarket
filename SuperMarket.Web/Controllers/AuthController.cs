using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Associate.DTO;
using SuperMarket.Business.Services.Abstract;

namespace SuperMarket.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAppUserService service;
        public AuthController(IAppUserService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AppUserDTO model)
        {
            string result = service.Login(model);
            if (result != "-1" )
            {
                HttpContext.Session.SetString("currentUser", result);
                return RedirectToAction("List", "Product");
            }
            TempData["Warning"] = "Şifre veya kullanıcı adınız hatalı";
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("currentUser");
            return RedirectToAction("Login");
       }
        
    }
}
