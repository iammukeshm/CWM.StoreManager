using CWM.Core.Essentials.Abstractions;

namespace CWM.StoreManager.Domain.Entities.Catalog
{
    public class CatalogType : BaseEntity
    {
        public string Type { get; private set; }
        public CatalogType(string type)
        {
            Type = type;
        }
    }
}
