using AutoMapper;
using CWM.StoreManager.Application.Features.Catalog.Queries.GetCatalogItems;
using CWM.StoreManager.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Application.Mappings
{
    public class CatalogMappings : Profile
    {
        public CatalogMappings()
        {
            CreateMap<CatalogItem, GetCatalogItemsViewModel>().ReverseMap();
        }
    }
}
