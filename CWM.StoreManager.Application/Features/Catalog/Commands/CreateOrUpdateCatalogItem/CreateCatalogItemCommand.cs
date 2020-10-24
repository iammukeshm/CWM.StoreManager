using CWM.Core.Essentials.Results;
using CWM.StoreManager.Application.Abstractions.Models;
using CWM.StoreManager.Application.Abstractions.Persistence;
using CWM.StoreManager.Domain.Entities.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Features.Catalog.Commands.CreateOrUpdateCatalogItem
{
    public partial class CreateCatalogItemCommand : IViewModel, IRequest<Result<string>>
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int CatalogTypeId { get; set; }
        public int CatalogBrandId { get; set; }
    }
    public class CreateCatalogItemCommandHandler : IRequestHandler<CreateCatalogItemCommand, Result<string>>
    {
        private readonly ICatalogContext _catalogContext;
        public CreateCatalogItemCommandHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<Result<string>> Handle(CreateCatalogItemCommand request, CancellationToken cancellationToken)
        {
            var item = new CatalogItem(
                request.CatalogTypeId, 
                request.CatalogBrandId, 
                request.Description, 
                request.Name, 
                request.Price, 
                request.PictureUri);
            _catalogContext.CatalogItems.Add(item);
            await _catalogContext.SaveChangesAsync(cancellationToken);
            return Result<string>.Success($"Catalog Item with Id {item.Id} Created.");
        }
    }
}
