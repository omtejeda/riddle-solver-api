using MediatR;
using RiddleSolver.Core.Features.WaterJugs.DTOs;
using RiddleSolver.Core.Models;

namespace RiddleSolver.Core.Features.WaterJugs.UseCases.Solve;

public record SolveWaterJugCommand(int CapacityX, int CapacityY, int AmountWanted) : IRequest<Result<WaterJugResponseDto>>;