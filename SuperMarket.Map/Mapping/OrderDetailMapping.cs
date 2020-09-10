using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Mapping;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Map.Mapping
{
    public class OrderDetailMapping : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => new { x.ProductId,x.OrderId });

            builder.HasOne<Product>(navigationExpression: uf => uf.Product)
                .WithMany(navigationExpression: nf => nf.OrderDetails)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne<Order>(navigationExpression: uf => uf.Order)
                .WithMany(navigationExpression: nf => nf.OrderDetails)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
