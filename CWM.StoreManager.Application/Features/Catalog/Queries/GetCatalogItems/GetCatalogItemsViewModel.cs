using CWM.StoreManager.Application.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Application.Features.Catalog.Queries.GetCatalogItems
{
    public class GetCatalogItemsViewModel : IViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
