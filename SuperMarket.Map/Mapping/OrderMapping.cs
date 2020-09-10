using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Mapping;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Map.Mapping
{
    public class OrderMapping:BaseMapping<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.PaymentType).IsRequired(true);
            builder.Property(x => x.TotalAmount).IsRequired(true);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.AppUserId);
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
            base.Configure(builder);
        }
    }
}
