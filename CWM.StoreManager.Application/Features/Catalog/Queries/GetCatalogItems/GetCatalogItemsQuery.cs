using CWM.Core.Essentials.Extensions;
using CWM.Core.Essentials.Results;
using CWM.StoreManager.Application.Abstractions.Persistence;
using CWM.StoreManager.Domain.Entities.Catalog;
using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Features.Catalog.Queries.GetCatalogItems
{
    public class GetCatalogItemsQuery : IRequest<PaginatedResult<GetCatalogItemsViewModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetCatalogItemsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
    
    public class GetCatalogItemsQueryHandler : IRequestHandler<GetCatalogItemsQuery, PaginatedResult<GetCatalogItemsViewModel>>
    {
        private readonly ICatalogContext _catalogContext;
        public GetCatalogItemsQueryHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }
        public async Task<PaginatedResult<GetCatalogItemsViewModel>> Handle(GetCatalogItemsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<CatalogItem, GetCatalogItemsViewModel>> expression = e => new GetCatalogItemsViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Price = e.Price,
                PictureUri = e.PictureUri,
                Type = e.CatalogType.Type,
                Brand = e.CatalogBrand.Brand
            };
            var paginatedList = await _catalogContext.CatalogItems
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;

        }
    }
}
