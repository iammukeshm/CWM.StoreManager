using CWM.StoreManager.Application.Features.Brand.Queries.GetBrandById;
using CWM.StoreManager.Application.Features.Brand.Queries.GetBrands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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