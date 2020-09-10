using SuperMarket.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entity.Entities
{
   public class Order:BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public string PaymentType { get; set; }

        public int AppUserId { get; set; }
        public virtual AppUser AppUser{ get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
