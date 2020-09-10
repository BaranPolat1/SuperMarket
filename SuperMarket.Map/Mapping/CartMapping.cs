using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Mapping;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Map.Mapping
{
    public class CartMapping:BaseMapping<Cart>
    {
        public override void Configure(EntityTypeBuilder<Cart> builder)
        {
           

            builder.HasOne(x => x.AppUser).WithOne(x => x.Cart).HasForeignKey<Cart>(x => x.Id);
            builder.HasMany(x => x.CartItems).WithOne(x => x.Cart).HasForeignKey(x => x.CartId);
            base.Configure(builder);
        }
    }
}
