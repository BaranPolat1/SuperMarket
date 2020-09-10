using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Associate.DTO;
using SuperMarket.Business.Services.Abstract;

namespace SuperMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
        public ProductController(IProductService service)
        {
            this.service = service;
        }
        [HttpPost("add")]
        public IActionResult Add(ProductDTO model)
        {
            if (service.AddProduct(model))
            {
                return Ok("Product has been added");
            }
            else
            {
                return BadRequest("Something is wrong");
            }

        }
        [HttpGet("list")]
        public IActionResult GetList()
        {
            var list = service.GetList();
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest("Something is wrong");
            }
        }
    }
}
