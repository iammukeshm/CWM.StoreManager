using AutoMapper;
using CWM.StoreManager.Application.Abstractions.Persistence;
using CWM.StoreManager.Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Features.Catalog.Queries.GetCatalogItems
{
    public class GetCatalogItemsQuery : IRequest<PaginatedResult<IEnumerable<GetCatalogItemsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetCatalogItemsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
    
    public class GetCatalogItemsQueryHandler : IRequestHandler<GetCatalogItemsQuery, PaginatedResult<IEnumerable<GetCatalogItemsViewModel>>>
    {
        private readonly ICatalogContext _catalogContext;
        private readonly IMapper _mapper;
        public GetCatalogItemsQueryHandler(IMapper mapper, ICatalogContext catalogContext)
        {
            _mapper = mapper;
            _catalogContext = catalogContext;
        }
        public async Task<PaginatedResult<IEnumerable<GetCatalogItemsViewModel>>> Handle(GetCatalogItemsQuery request, CancellationToken cancellationToken)
        {
            request.PageNumber = request.PageNumber == 0 ? 1 : request.PageNumber;
            request.PageSize = request.PageSize == 0 ? 10 : request.PageSize;

            var catalogItems = await _catalogContext.CatalogItems
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
            var count = await _catalogContext.CatalogItems.CountAsync(); 
            var catalogItemsViewModel =  _mapper.Map<IEnumerable<GetCatalogItemsViewModel>>(catalogItems);
            return PaginatedResult<IEnumerable<GetCatalogItemsViewModel>>
                .Success(catalogItemsViewModel, count, request.PageNumber, request.PageSize);

        }
    }
}
