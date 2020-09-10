using SuperMarket.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entity.Entities
{
   public class CartItem
    {
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
