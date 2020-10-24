

using CWM.Core.Essentials.ValidatR;

namespace CWM.StoreManager.Domain.Entities.Catalog
{
    public class CatalogItem : AuditableEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public int CatalogTypeId { get; private set; }
        public CatalogType CatalogType { get; private set; }
        public int CatalogBrandId { get; private set; }
        public CatalogBrand CatalogBrand { get; private set; }

        public CatalogItem(int catalogTypeId,
            int catalogBrandId,
            string description,
            string name,
            decimal price,
            string pictureUri)
        {
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrandId;
            Description = description;
            Name = name;
            Price = price;
            PictureUri = pictureUri;
        }
        public void UpdateDetails(string name, string description, decimal price)
        {
            Throw.Exception.IfNull(name, nameof(name));
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
