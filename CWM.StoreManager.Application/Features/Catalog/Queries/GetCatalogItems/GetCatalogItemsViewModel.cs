using CWM.StoreManager.Application.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Application.Features.Catalog.Queries.GetCatalogItems
{
    public class GetCatalogItemsViewModel : IViewModel
    {
        public string Name { get;  set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public string Type { get; set; }

        public string Brand { get; set; }
    }
}
