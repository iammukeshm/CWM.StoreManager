using CWM.StoreManager.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Application.Abstractions.Persistence
{
    public interface ICatalogContext : IApplicationDbContext
    {
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
    }
}
