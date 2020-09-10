using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Associate.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentType { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
