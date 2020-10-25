using CWM.Core.Essentials.Caching;
using CWM.Core.Essentials.Results;
using CWM.StoreManager.Application.Abstractions.Persistence;
using CWM.StoreManager.Application.Constants.CacheKeys;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Features.Brand.Queries.GetBrands
{
    public class GetBrandsQuery : IRequest<Result<IEnumerable<BrandViewModel>>>
    {
    }
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, Result<IEnumerable<BrandViewModel>>>
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IApplicationDbConnection _dbConnection;
        public GetBrandsQueryHandler(IApplicationDbConnection dbConnection, IDistributedCache distributedCache)
        {
            _dbConnection = dbConnection;
            _distributedCache = distributedCache;
        }
        public async Task<Result<IEnumerable<BrandViewModel>>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = BrandCacheKeys.ListKey;
            var brands = await _distributedCache.GetAsync<IEnumerable<BrandViewModel>>(cacheKey, cancellationToken);
            if (brands == null)
            {
                brands = await _dbConnection.QueryAsync<BrandViewModel>("Select * from CatalogBrands", null, null, cancellationToken);
                await _distributedCache.SetAsync(cacheKey, brands);
            }
            return Result<IEnumerable<BrandViewModel>>.Success(brands);
        }
    }
}
