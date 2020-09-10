using SuperMarket.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entity.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
