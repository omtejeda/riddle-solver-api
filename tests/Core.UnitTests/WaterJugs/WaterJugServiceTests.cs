using RiddleSolver.Core.Features.WaterJugs.Services;
using RiddleSolver.Core.Features.WaterJugs.Models;

namespace RiddleSolver.Core.UnitTests.WaterJugs;

public class WaterJugServiceTests
{
    private readonly WaterJugService _waterJugService;

    public WaterJugServiceTests()
    {
        _waterJugService = new WaterJugService();
    }

    [Theory]
    [MemberData(nameof(GetValidSolutions))]
    public void Solve_ShouldReturnSolvedSolutions(WaterJug waterJug)
    {
        var actual = _waterJugService.Solve(waterJug);

        Assert.True(actual.Success);
        Assert.Equal("Solved", actual.Message, StringComparer.OrdinalIgnoreCase);
        Assert.NotNull(actual.Data?.Solution);
        Assert.NotEmpty(actual.Data.Solution);
    }

    [Theory]
    [MemberData(nameof(GetInvalidSolutions))]
    public void Solve_ShouldReturnThatIsNotPossibleToSolve(WaterJug waterJug)
    {
        var actual = _waterJugService.Solve(waterJug);

        Assert.False(actual.Success);
        Assert.Equal("No Solution", actual.Message, StringComparer.OrdinalIgnoreCase);
        Assert.Null(actual.Data?.Solution);
    }

    #region TestData
    public static TheoryData<WaterJug> GetValidSolutions()
    {
        return new()
        {
            new WaterJug(2, 10, 4),
            new WaterJug(2, 100, 96),
            new WaterJug(3, 5, 4),
            new WaterJug(5, 2, 4),
            new WaterJug(7, 3, 4),
            new WaterJug(5, 3, 1),
            new WaterJug(8, 3, 5),
            new WaterJug(10, 6, 4),
            new WaterJug(10, 4, 6),
            new WaterJug(10, 10, 10),
            new WaterJug(5, 3, 3),
            new WaterJug(15, 7, 14),
            new WaterJug(6, 8, 4),
            new WaterJug(8, 10, 6),
            new WaterJug(12, 6, 6),
            new WaterJug(9, 4, 5),
            new WaterJug(14, 6, 8),
            new WaterJug(3, 9, 6),
            new WaterJug(11, 5, 1),
            new WaterJug(13, 8, 5),
            new WaterJug(16, 4, 12),
            new WaterJug(6, 10, 2),
            new WaterJug(4, 10, 4),
            new WaterJug(5, 9, 1),
            new WaterJug(30, 10, 20),
            new WaterJug(50, 30, 20),
            new WaterJug(12, 5, 6),
            new WaterJug(7, 3, 1),
            new WaterJug(9, 4, 3),
            new WaterJug(13, 6, 11),
            new WaterJug(11, 8, 4),
            new WaterJug(13, 9, 6),
            new WaterJug(10, 7, 6)
        };
    }

    public static TheoryData<WaterJug> GetInvalidSolutions()
    {
        return new()
        {
            new WaterJug(2, 6, 5),
            new WaterJug(20, 10, 5),
            new WaterJug(15, 10, 7),
            new WaterJug(8, 6, 5),
            new WaterJug(12, 8, 5),
            new WaterJug(14, 7, 2),
            new WaterJug(18, 12, 7),
            new WaterJug(10, 5, 8),
            new WaterJug(22, 11, 9),
            new WaterJug(6, 4, 3),
            new WaterJug(16, 12, 7),
            new WaterJug(30, 20, 15),
            new WaterJug(24, 10, 9),
            new WaterJug(25, 10, 12),
            new WaterJug(50, 30, 29),
            new WaterJug(40, 15, 7),
            new WaterJug(33, 22, 5),
            new WaterJug(35, 28, 11),
            new WaterJug(60, 40, 25),
            new WaterJug(90, 45, 20),
            new WaterJug(70, 50, 21),
            new WaterJug(80, 30, 7)
        };
    }
    #endregion
}