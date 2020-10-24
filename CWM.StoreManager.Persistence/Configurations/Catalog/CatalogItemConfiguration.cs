using CWM.StoreManager.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Persistence.Configurations.Catalog
{
    public class CatalogItemConfiguration : ConfigurationBase<CatalogItem>
    {
        public override void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(e => e.Price).HasColumnType(PersistenceLayerConstants.SqlDecimalType);
        }
    }
}
