using CWM.Core.Essentials.Results;
using CWM.Core.Essentials.ValidatR;
using CWM.StoreManager.Application.Abstractions.Persistence;
using CWM.StoreManager.Domain.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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
        private readonly ICatalogContext _catalogContext;
        public GetCatalogItemsQueryHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }
        public async Task<Result<CatalogItemViewModel>> Handle(GetCatalogItemByIdQuery request, CancellationToken cancellationToken)
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
            var item = await _catalogContext.CatalogItems
                .Where(e => e.Id == request.Id)
                .Select(expression).FirstOrDefaultAsync();
            Throw.Exception.IfEntityNotFound(request.Id,item, "Catalog Item");
            return Result<CatalogItemViewModel>.Success(item);

        }
    }
}
