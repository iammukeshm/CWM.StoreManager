using CWM.DotNetCore.Results;
using CWM.DotNetCore.ValidatR;
using CWM.StoreManager.Application.Abstractions.Models;
using CWM.StoreManager.Application.Abstractions.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Features.Catalog.Commands.DeleteCatalogItem
{
    public partial class DeleteCatalogItemCommand : IViewModel, IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class DeleteCatalogItemCommandHandler : IRequestHandler<DeleteCatalogItemCommand, Result>
    {
        private readonly ICatalogContext _catalogContext;

        public DeleteCatalogItemCommandHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<Result> Handle(DeleteCatalogItemCommand request, CancellationToken cancellationToken)
        {
            var itemToBeDeleted = await _catalogContext.CatalogItems.FindAsync(request.Id);
            Throw.Exception.IfEntityNotFound(request.Id, itemToBeDeleted, "Catalog Item");
            _catalogContext.CatalogItems.Remove(itemToBeDeleted);
            await _catalogContext.SaveChangesAsync(cancellationToken);
            return Result.EntityDeleted(itemToBeDeleted.Id, "Catalog Item");
        }
    }
}