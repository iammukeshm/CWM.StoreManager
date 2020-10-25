using CWM.DotNetCore.Results;
using CWM.DotNetCore.Caching;
using CWM.DotNetCore.ValidatR;
using CWM.StoreManager.Application.Abstractions.Persistence;
using CWM.StoreManager.Domain.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Features.Catalog.Queries.GetCatalogItemById
{
    public class GetCatalogItemByIdQuery : IRequest<Result<CatalogItemViewModel>>
    {
        public int Id { get; set; }
        public GetCatalogItemByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetCatalogItemsQueryHandler : IRequestHandler<GetCatalogItemByIdQuery, Result<CatalogItemViewModel>>
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ICatalogContext _catalogContext;
        public GetCatalogItemsQueryHandler(ICatalogContext catalogContext, IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
            _catalogContext = catalogContext;
        }
        public async Task<Result<CatalogItemViewModel>> Handle(GetCatalogItemByIdQuery request, CancellationToken cancellationToken)
        {
            
            var cacheKey = $"Item-{request.Id}";
            var data = await _distributedCache.GetAsync<CatalogItemViewModel>(cacheKey);
            if(data==null)
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
                data = await _catalogContext.CatalogItems
                .Where(e => e.Id == request.Id)
                .Select(expression).FirstOrDefaultAsync();
                Throw.Exception.IfEntityNotFound(request.Id, data, "Catalog Item");
                await _distributedCache.SetAsync<CatalogItemViewModel>("Item", data);
            }
            return Result<CatalogItemViewModel>.Success(data);

        }
    }
}
