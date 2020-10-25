using CWM.Core.Essentials.Results;
using CWM.Core.Essentials.ValidatR;
using CWM.StoreManager.Application.Abstractions.Models;
using CWM.StoreManager.Application.Abstractions.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Features.Catalog.Commands.UpdateCatalogItem
{
    public partial class UpdateCatalogItemCommand : IViewModel, IRequest<Result<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int CatalogTypeId { get; set; }
        public int CatalogBrandId { get; set; }
    }
    public class UpdateCatalogItemCommandHandler : IRequestHandler<UpdateCatalogItemCommand, Result<string>>
    {
        private readonly ICatalogContext _catalogContext;
        public UpdateCatalogItemCommandHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<Result<string>> Handle(UpdateCatalogItemCommand request, CancellationToken cancellationToken)
        {
            
            var item = await _catalogContext.CatalogItems.FindAsync(request.Id);
            Throw.Exception.IfEntityNotFound(request.Id, item, "Catalog Item");
            _catalogContext.Entry(item).CurrentValues.SetValues(request);
            await _catalogContext.SaveChangesAsync(cancellationToken);
            return Result<string>.Success($"Catalog Item with Id {item.Id} Updated.");
        }
    }
}
