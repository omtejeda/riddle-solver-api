using FluentValidation;

namespace RiddleSolver.Core.Features.WaterJugs.UseCases.Solve;

public class SolveWaterJugValidator : AbstractValidator<SolveWaterJugCommand>
{
    const int MustBeGreaterThan = 0;
    const string MustBeGreaterThanMessage = "{PropertyName} cannot be less than or equal to zero";

    public SolveWaterJugValidator()
    {
        RuleFor(command => command.CapacityX)
            .GreaterThan(MustBeGreaterThan)
            .WithMessage(MustBeGreaterThanMessage);
        
        RuleFor(command => command.CapacityY)
            .GreaterThan(MustBeGreaterThan)
            .WithMessage(MustBeGreaterThanMessage);

        RuleFor(command => command.AmountWanted)
            .GreaterThan(MustBeGreaterThan)
            .WithMessage(MustBeGreaterThanMessage);
    }
}