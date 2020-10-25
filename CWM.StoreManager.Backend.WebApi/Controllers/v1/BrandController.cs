using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWM.StoreManager.Application.Features.Brand.Queries.GetBrandById;
using CWM.StoreManager.Application.Features.Brand.Queries.GetBrands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CWM.StoreManager.Backend.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    public class BrandController : BaseApiController<BrandController>
    {
        [HttpGet]
        public async Task<IActionResult> GetBrandsAsync()
        {
            return Ok(await _mediator.Send(new GetBrandsQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandDetailsAsync(int id)
        {
            return Ok(await _mediator.Send(new GetBrandByIdQuery(id)));
        }
    }
}
