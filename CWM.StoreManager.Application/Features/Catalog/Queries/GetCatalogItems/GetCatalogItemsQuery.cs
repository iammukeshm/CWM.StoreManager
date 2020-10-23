using CWM.StoreManager.Application.Abstractions.Persistence;
using MediatR;
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
        private static string Query => "Select * from ActivityLogs";
        private readonly IApplicationDbConnection _applicationDbConnection;
        public GetCatalogItemsQueryHandler(IApplicationDbConnection applicationDbConnection)
        {
            _applicationDbConnection = applicationDbConnection;
        }
        public List<GetCatalogItemsViewModel> CatalogItemsViewModels { get; set; } = new List<GetCatalogItemsViewModel>
            {
                 new GetCatalogItemsViewModel{ Id  = 1, Name = "Product1"},
                 new GetCatalogItemsViewModel{ Id  = 2, Name = "Product2"},
                 new GetCatalogItemsViewModel{ Id  = 3, Name = "Product3"},
                 new GetCatalogItemsViewModel{ Id  = 4, Name = "Product4"},
                 new GetCatalogItemsViewModel{ Id  = 5, Name = "Product5"},
                 new GetCatalogItemsViewModel{ Id  = 6, Name = "Product6"},
            };
        public async Task<IEnumerable<GetCatalogItemsViewModel>> Handle(GetCatalogItemsQuery request, CancellationToken cancellationToken)
        {
            //TEST
            var result = await _applicationDbConnection.QueryAsync<ActivityLog>(Query, null, null, cancellationToken);
            request.PageNumber = request.PageNumber == 0 ? 1 : request.PageNumber;
            request.PageSize = request.PageSize == 0 ? 2 : request.PageSize;
            var catalogs = CatalogItemsViewModels.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);
            return catalogs.AsEnumerable();
        }
    }
}
