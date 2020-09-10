using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Associate.DTO
{
    public class CartDTO
    {
        public int Id { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
