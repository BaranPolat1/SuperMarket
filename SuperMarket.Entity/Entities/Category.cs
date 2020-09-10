using SuperMarket.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entity.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
