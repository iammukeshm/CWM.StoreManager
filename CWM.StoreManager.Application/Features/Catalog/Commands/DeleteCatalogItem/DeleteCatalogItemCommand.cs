using CWM.Core.Essentials.Results;
using CWM.Core.Essentials.ValidatR;
using CWM.StoreManager.Application.Abstractions.Models;
using CWM.StoreManager.Application.Abstractions.Persistence;
using CWM.StoreManager.Domain.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Features.Catalog.Commands.DeleteCatalogItem
{
    public partial class DeleteCatalogItemCommand : IViewModel, IRequest<Result<string>>
    {
        public int Id{ get; set; }
    }
    public class DeleteCatalogItemCommandHandler : IRequestHandler<DeleteCatalogItemCommand, Result<string>>
    {
        private readonly ICatalogContext _catalogContext;
        public DeleteCatalogItemCommandHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<Result<string>> Handle(DeleteCatalogItemCommand request, CancellationToken cancellationToken)
        {
            var itemToBeDeleted = await _catalogContext.CatalogItems.FindAsync(request.Id);
            Throw.Exception.IfEntityNotFound(request.Id, itemToBeDeleted, "Catalog Item");
            _catalogContext.CatalogItems.Remove(itemToBeDeleted);
            await _catalogContext.SaveChangesAsync(cancellationToken);
            return Result<string>.EntityDeleted(itemToBeDeleted.Id, "Catalog Item");
        }
    }
}
