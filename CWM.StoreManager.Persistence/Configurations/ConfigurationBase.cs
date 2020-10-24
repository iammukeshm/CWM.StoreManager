using CWM.StoreManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Persistence.Configurations
{
    public abstract class ConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : AuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.CreatedBy).IsRequired();
        }
    }
}
