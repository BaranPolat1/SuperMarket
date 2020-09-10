using Microsoft.AspNetCore.Http;
using SuperMarket.Associate.CustomValidation;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;


namespace SuperMarket.Associate.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
 
        [FileExtension]
        public IFormFile ImageUpload { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
