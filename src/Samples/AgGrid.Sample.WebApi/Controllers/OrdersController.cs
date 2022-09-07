using AgGrid.AgGridExtensions;
using AgGrid.Sample.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgGrid.Sample.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(AgGridResult),StatusCodes.Status200OK)]
    public ActionResult<AgGridResult> Get([FromQuery]AgGridRequest request)
    {
        var result = DataStore.Orders().ToAgGridResult(request);
        return Ok(result);
    }
}