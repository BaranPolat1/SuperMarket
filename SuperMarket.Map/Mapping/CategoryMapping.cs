using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Mapping;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Map.Mapping
{
   public class CategoryMapping:BaseMapping<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(255);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            base.Configure(builder);
        }
    }
}
