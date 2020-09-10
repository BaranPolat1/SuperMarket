using Microsoft.AspNetCore.Identity;
using SuperMarket.Core.Entity;
using System.Collections.Generic;

namespace SuperMarket.Entity.Entities
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
