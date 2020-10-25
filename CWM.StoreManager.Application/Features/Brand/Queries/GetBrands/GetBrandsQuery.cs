using CWM.Core.Essentials.Results;
using CWM.StoreManager.Application.Abstractions.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Features.Brand.Queries.GetBrands
{
    public class GetBrandsQuery : IRequest<Result<IEnumerable<BrandViewModel>>>
    {
    }
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, Result<IEnumerable<BrandViewModel>>>
    {
        private readonly IApplicationDbConnection _dbConnection;
        public GetBrandsQueryHandler(IApplicationDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<Result<IEnumerable<BrandViewModel>>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _dbConnection.QueryAsync<BrandViewModel>("Select * from CatalogBrands", null, null, cancellationToken);
            return Result<IEnumerable<BrandViewModel>>.Success(brands);
        }
    }
}
