using CWM.StoreManager.Application.Abstractions.Persistence;
using CWM.StoreManager.Domain.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Features.Catalog.Queries.GetCatalogItems
{
    public class GetCatalogItemsQuery : IRequest<IEnumerable<GetCatalogItemsViewModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetCatalogItemsQueryHandler : IRequestHandler<GetCatalogItemsQuery, IEnumerable<GetCatalogItemsViewModel>>
    {
        private static string Query => "Select * from CatalogItems";
        private readonly IApplicationDbConnection _applicationDbConnection;
        private readonly ICatalogContext _catalogContext;
        public GetCatalogItemsQueryHandler(IApplicationDbConnection applicationDbConnection, ICatalogContext catalogContext)
        {
            _applicationDbConnection = applicationDbConnection;
            _catalogContext = catalogContext;
        }
        public async Task<IEnumerable<GetCatalogItemsViewModel>> Handle(GetCatalogItemsQuery request, CancellationToken cancellationToken)
        {
            //TEST
            var data = await _catalogContext.CatalogItems.Include(a=>a.CatalogBrand).Include(s=>s.CatalogType).ToListAsync();
            var result = await _applicationDbConnection.QueryAsync<GetCatalogItemsViewModel>(Query, null, null, cancellationToken);
            return result.ToList();
        }
    }
}
