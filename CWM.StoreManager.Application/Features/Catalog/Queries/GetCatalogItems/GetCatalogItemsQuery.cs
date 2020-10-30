using CWM.DotNetCore.Extensions;
using CWM.DotNetCore.Results;
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
    public class GetCatalogItemsQuery : IRequest<PaginatedResult<CatalogItemViewModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetCatalogItemsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetCatalogItemsQueryHandler : IRequestHandler<GetCatalogItemsQuery, PaginatedResult<CatalogItemViewModel>>
    {
        private readonly ICatalogContext _catalogContext;

        public GetCatalogItemsQueryHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<PaginatedResult<CatalogItemViewModel>> Handle(GetCatalogItemsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<CatalogItem, CatalogItemViewModel>> expression = e => new CatalogItemViewModel
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