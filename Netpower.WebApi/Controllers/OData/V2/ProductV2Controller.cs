using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Netpower.WebApi.Controllers.OData.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("odata/v{v:apiVersion}")]
    public class ProductV2Controller : ODataController
    {

        public ProductV2Controller()
        {
        }

        [EnableQuery]
        [MapToApiVersion("2.0")]
        [HttpGet, Route("Products")]
        [HttpGet, Route("Products/$count")]
        public IActionResult Get()
        {
            return Ok("This is Products V2");
        }
    }
}