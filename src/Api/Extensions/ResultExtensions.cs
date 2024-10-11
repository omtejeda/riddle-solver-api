using Microsoft.AspNetCore.Mvc;
using RiddleSolver.Core.Models;
using RiddleSolver.Core.Enums;

namespace RiddleSolver.Api.Extensions;

/// <summary>
/// Extension methods for <see cref="Result{T}"/>.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Converts a <see cref="Result{T}"/> to an <see cref="IActionResult"/>.
    /// </summary>
    /// <typeparam name="T">The type of the result data.</typeparam>
    /// <param name="result">The result to convert.</param>
    /// <returns>An <see cref="IActionResult"/> based on the result succes and/or status.</returns>
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