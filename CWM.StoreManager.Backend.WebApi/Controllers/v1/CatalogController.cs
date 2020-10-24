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
    }
}
