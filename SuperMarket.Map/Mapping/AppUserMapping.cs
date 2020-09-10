using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Mapping;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Map.Mapping
{
    public class AppUserMapping:BaseMapping<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
           
            builder.Property(x => x.Email).IsRequired(true);
            builder.Property(x => x.FullName).IsRequired(true);
            builder.Property(x => x.Phone).IsRequired(true);
            builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(10);
            builder.HasMany(x => x.Orders).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.Cart).WithOne(x => x.AppUser).HasForeignKey<Cart>(x => x.Id);
            base.Configure(builder);
        }
    }
}
