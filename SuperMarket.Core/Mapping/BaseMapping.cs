using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Core.Mapping
{
    public abstract class BaseMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ModifiedComputerName).IsRequired(false).ValueGeneratedOnUpdate();
            builder.Property(x => x.ModifiedDate).IsRequired(false).ValueGeneratedOnUpdate();
            builder.Property(x => x.ModifiedIP).IsRequired(false).ValueGeneratedOnUpdate();
            builder.Property(x => x.CreatedComputerName).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedIP).ValueGeneratedOnAdd();

           
        }
    }
}
