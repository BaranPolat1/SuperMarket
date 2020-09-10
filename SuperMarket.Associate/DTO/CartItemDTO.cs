using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Associate.DTO
{
    public class CartItemDTO
    {
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
