using SuperMarket.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entity.Entities
{
    public class OrderDetail
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
