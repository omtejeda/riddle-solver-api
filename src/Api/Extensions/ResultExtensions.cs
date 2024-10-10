using Microsoft.AspNetCore.Mvc;
using RiddleSolver.Core.Models;
using RiddleSolver.Core.Enums;

namespace RiddleSolver.Api.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result) where T : class
    {
        return result.Success switch
        {
            true => new OkObjectResult(result),
            _ when result.Status.Equals(Status.Unprocessable.ToString()) => new UnprocessableEntityObjectResult(result),
            _ => new BadRequestObjectResult(result)
        };
    }
}