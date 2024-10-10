using Microsoft.AspNetCore.Mvc;
using RiddleSolver.Core.Contracts;
using RiddleSolver.Core.Models;
using RiddleSolver.Api.Extensions;
using RiddleSolver.Api.Constants;
using RiddleSolver.Core.Features.WaterJugs.UseCases.Solve;
using RiddleSolver.Core.Features.WaterJugs.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using MediatR;

namespace RiddleSolver.Api.Controllers.v1;

[ApiController]
[ApiVersion(ApiVersions.v1)]
[Route("[controller]")]
public class WaterJugController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [SwaggerOperation("Solve water jug riddle")]
    [ProducesResponseType(typeof(Result<WaterJugResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result<INoDataResponse>), StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> Solve([FromBody] SolveWaterJugCommand request)
    {
        var result = await _sender.Send(request);
        return result.ToActionResult();
    }
}