using CWM.DotNetCore.Results;
using CWM.DotNetCore.ValidatR;
using CWM.StoreManager.Application.Abstractions.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Features.Brand.Queries.GetBrandById
{
    public class GetBrandByIdQuery : IRequest<Result<BrandViewModel>>
    {
        public GetBrandByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Result<BrandViewModel>>
    {
        private readonly IApplicationDbConnection _dbConnection;
        public GetBrandByIdQueryHandler(IApplicationDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<Result<BrandViewModel>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _dbConnection.QueryFirstOrDefaultAsync<BrandViewModel>($"Select * from CatalogBrands where Id = {request.Id}", null, null, cancellationToken);
            Throw.Exception.IfEntityNotFound(request.Id, brand, "Brand");
            return Result<BrandViewModel>.Success(brand);
        }
    }
}
