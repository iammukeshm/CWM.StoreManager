using CWM.StoreManager.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CWM.StoreManager.Persistence.Configurations.Catalogs
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
