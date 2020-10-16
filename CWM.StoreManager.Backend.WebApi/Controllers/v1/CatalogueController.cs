using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CWM.StoreManager.Backend.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueController : BaseApiController<CatalogueController>
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogError("Hi!");
            return Ok();
        }
    }
}
