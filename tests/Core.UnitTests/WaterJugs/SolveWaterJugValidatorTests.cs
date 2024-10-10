using FluentValidation.TestHelper;
using RiddleSolver.Core.Features.WaterJugs.UseCases.Solve;

namespace RiddleSolver.Core.UnitTests.WaterJugs;

public class SolveWaterJugValidatorTests
{
    private readonly SolveWaterJugValidator _validator;

    public SolveWaterJugValidatorTests()
    {
        _validator = new SolveWaterJugValidator();
    }

    [Fact]
    public void ShouldHaveError_WhenCapacityXIsNotAPositiveInteger()
    {
        // Arrange
        var command = new SolveWaterJugCommand(0, 5, 3);

        // Act
        var actual = _validator.TestValidate(command);

        // Assert
        actual.ShouldHaveValidationErrorFor(x => x.CapacityX);
    }

    [Fact]
    public void ShouldHaveError_WhenCapacityYIsNotAPositiveInteger()
    {
        // Arrange
        var command = new SolveWaterJugCommand(3, -1, 7);

        // Act
        var actual = _validator.TestValidate(command);

        // Assert
        actual.ShouldHaveValidationErrorFor(x => x.CapacityY);
    }

    [Fact]
    public void ShouldHaveError_WhenAmountWantedIsNotAPositiveInteger()
    {
        // Arrange
        var command = new SolveWaterJugCommand(19, 20, -33);

        // Act
        var actual = _validator.TestValidate(command);

        // Assert
        actual.ShouldHaveValidationErrorFor(x => x.AmountWanted);
    }

    [Fact]
    public void ShouldNotHaveError_WhenValidInputsAreProvided()
    {
        // Arrange
        var command = new SolveWaterJugCommand(5, 3, 1);

        // Act
        var result = _validator.TestValidate(command);

        //Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}