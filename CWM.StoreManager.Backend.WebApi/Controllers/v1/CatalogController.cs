using CWM.Core.Essentials.ValidatR;
using CWM.StoreManager.Application.Features.Catalog.Commands.CreateCatalogItem;
using CWM.StoreManager.Application.Features.Catalog.Commands.DeleteCatalogItem;
using CWM.StoreManager.Application.Features.Catalog.Commands.UpdateCatalogItem;
using CWM.StoreManager.Application.Features.Catalog.Queries.GetCatalogItemById;
using CWM.StoreManager.Application.Features.Catalog.Queries.GetCatalogItems;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CWM.StoreManager.Backend.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CatalogController : BaseApiController<CatalogController>
    {
        [HttpGet]
        public async Task<IActionResult> GetCatalogItemsAsync(int pageNumber,int pageSize)
        {
            return Ok(await _mediator.Send(new GetCatalogItemsQuery(pageNumber, pageSize)));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatalogItemDetailsAsync(int id)
        {
            return Ok(await _mediator.Send(new GetCatalogItemByIdQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCatalogItemAsync(CreateCatalogItemCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCatalogItemAsync(int id, UpdateCatalogItemCommand command)
        {
            Throw.Exception.IfNotEqual<int>(id, command.Id, "CatalogItemId");
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCatalogItemAsync(DeleteCatalogItemCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
