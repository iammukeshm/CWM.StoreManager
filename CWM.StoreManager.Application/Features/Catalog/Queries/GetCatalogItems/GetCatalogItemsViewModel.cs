using CWM.StoreManager.Application.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Application.Features.Catalog.Queries.GetCatalogItems
{
    public class GetCatalogItemsViewModel : IViewModel
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public int CatalogTypeId { get; private set; }
    }
}
