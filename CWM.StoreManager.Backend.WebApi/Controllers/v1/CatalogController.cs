using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWM.StoreManager.Application.Features.Catalog.Queries.GetCatalogItems;
using CWM.StoreManager.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CWM.StoreManager.Backend.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CatalogController : BaseApiController<CatalogController>
    {
        [HttpGet]
        public async Task<IActionResult> GetCatalogItemsAsync(int pageSize, int pageNumber)
        {
            var result = await _mediator.Send(new GetCatalogItemsQuery());
            return Ok(PaginatedResult<IEnumerable<GetCatalogItemsViewModel>>.Success(result, 10, pageNumber, pageSize));
        }
    }
}
