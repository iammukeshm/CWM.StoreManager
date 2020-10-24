using CWM.StoreManager.Application.Features.Catalog.Commands.CreateOrUpdateCatalogItem;
using CWM.StoreManager.Application.Features.Catalog.Queries.GetCatalogItemById;
using CWM.StoreManager.Application.Features.Catalog.Queries.GetCatalogItems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
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
        public async Task<IActionResult> CreateOrUpdateCatalogItemAsync(CreateCatalogItemCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
