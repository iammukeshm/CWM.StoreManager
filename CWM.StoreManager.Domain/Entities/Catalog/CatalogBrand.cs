using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Domain.Entities.Catalog
{
    public class CatalogBrand : BaseEntity
    {
        public string Brand { get; private set; }
        public CatalogBrand(string brand)
        {
            Brand = brand;
        }
    }
}
