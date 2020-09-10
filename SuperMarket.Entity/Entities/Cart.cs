using SuperMarket.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SuperMarket.Entity.Entities
{
    public class Cart : BaseEntity
    {
      
        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
