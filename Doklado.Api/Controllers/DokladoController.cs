using Microsoft.AspNetCore.Mvc;
using Doklado.Integration.Services;
using Doklado.Integration.Contracts.Enums;

namespace Doklado.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DokladoController(DokladoHttpService service) : ControllerBase
{
    private readonly DokladoHttpService _dokladoService = service;

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Doklado API is working");
    }

    [HttpGet("documents")]
    public async Task<IActionResult> GetDocuments(
        [FromQuery] string organizationId,
        CancellationToken cancellationToken)
    {
        var json = await _dokladoService.GetDocumentsRawAsync(
            organizationId,
            DateTime.UtcNow.AddMonths(-1),
            DokladoDateType.Create,
            cancellationToken);

        return Content(json, "application/json");
    }
}