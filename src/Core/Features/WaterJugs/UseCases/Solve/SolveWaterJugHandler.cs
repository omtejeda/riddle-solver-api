using MediatR;
using FluentValidation;
using FluentValidation.Results;
using RiddleSolver.Core.Features.WaterJugs.DTOs;
using RiddleSolver.Core.Models;
using RiddleSolver.Core.Features.WaterJugs.Models;
using RiddleSolver.Core.Enums;
using RiddleSolver.Core.Helpers;
using RiddleSolver.Core.Contracts;

namespace RiddleSolver.Core.Features.WaterJugs.UseCases.Solve;

internal sealed class SolveWaterJugHandler(IValidator<SolveWaterJugCommand> validator, IWaterJugService waterJugService)
    : IRequestHandler<SolveWaterJugCommand, Result<WaterJugResponseDto>>
{
    private readonly IValidator<SolveWaterJugCommand> _validator = validator;
    private readonly IWaterJugService _waterJugService = waterJugService;
    
    public async Task<Result<WaterJugResponseDto>> Handle(SolveWaterJugCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result<WaterJugResponseDto>.Failed(Status.ValidationError, validationResult.GetFirstErrorMessage());
        }

        var waterJug = new WaterJug(request.CapacityX, request.CapacityY, request.AmountWanted);
        var result = _waterJugService.Solve(waterJug);
        
        return result;
    }
}