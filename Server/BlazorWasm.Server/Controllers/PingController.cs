using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasm.Server.Controllers;

[ApiController]
[Route("api/ping")]
[Produces(MediaTypeNames.Application.Json)]
public class PingController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IActionResult> PingAsync()
    {
         return Task.FromResult((IActionResult)Ok());
    }
}