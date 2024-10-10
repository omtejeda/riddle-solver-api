using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using RiddleSolver.Core.Contracts;
using RiddleSolver.Core.Enums;
using RiddleSolver.Core.Models;

namespace RiddleSolver.Api.Middlewares;

internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger = logger;

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An exception occured: {Message}", exception.Message);

        var result = Result<INoDataResponse>.Failed(Status.UnexpectedError, "An unexpected error ocurred. Check logs for details.");
        
        httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(result, cancellationToken);
        return true;
    }
}