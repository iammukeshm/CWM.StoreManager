using CWM.DotNetCore.Caching;
using CWM.DotNetCore.Results;
using CWM.StoreManager.Application.Abstractions.Persistence;
using CWM.StoreManager.Application.Constants.CacheKeys;
using CWM.StoreManager.Domain.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Features.Type.Queries.GetTypes
{
    public class GetTypesQuery : IRequest<Result<IEnumerable<TypeViewModel>>>
    {
    }

    public class GetTypesQueryHandler : IRequestHandler<GetTypesQuery, Result<IEnumerable<TypeViewModel>>>
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ICatalogContext _catalogContext;

        public GetTypesQueryHandler(ICatalogContext catalogContext, IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
            _catalogContext = catalogContext;
        }

        public async Task<Result<IEnumerable<TypeViewModel>>> Handle(GetTypesQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = TypeCacheKeys.ListKey;
            var types = await _distributedCache.GetAsync<IEnumerable<TypeViewModel>>(cacheKey, cancellationToken);
            if (types == null)
            {
                Expression<Func<CatalogType, TypeViewModel>> expression = e => new TypeViewModel
                {
                    Id = e.Id,
                    Type = e.Type
                };
                types = await _catalogContext.CatalogTypes.Select(expression).ToListAsync();
                await _distributedCache.SetAsync(cacheKey, types);
            }
            return Result<IEnumerable<TypeViewModel>>.Success(types);
        }
    }
}