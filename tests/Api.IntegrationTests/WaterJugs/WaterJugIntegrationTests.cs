using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace RiddleSolver.Api.IntegrationTests.WaterJugs;

public class WaterJugIntegrationTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient = factory.CreateClient();
    private const string RequestUrl = "/api/v1/riddles/waterjug";

    [Fact]
    public async Task SolveWaterJugEndpoint_WithValidInput_ShouldReturn200OK()
    {
        // Arrange
        var requestData = new { CapacityX = 3, CapacityY = 5, AmountWanted = 4 };

        // Act
        var response = await _httpClient.PostAsJsonAsync(RequestUrl, requestData);

        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Solved", result, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task SolveWaterJugEndpoint_WithValidationError_ShouldReturn400BadRequest()
    {
        // Arrange
        var requestData = new { CapacityX = 0, CapacityY = 5, AmountWanted = 4 };

        // Act
        var response = await _httpClient.PostAsJsonAsync(RequestUrl, requestData);

        // Assert
        var result = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Contains("ValidationError", result, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task SolveWaterJugEndpoint_WithNoSolution_ShouldReturn422Unprocessable()
    {
        // Arrange
        var requestData = new { CapacityX = 2, CapacityY = 6, AmountWanted = 5 };

        // Act
        var response = await _httpClient.PostAsJsonAsync(RequestUrl, requestData);

        // Assert
        var result = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        Assert.Contains("Unprocessable", result, StringComparison.OrdinalIgnoreCase);
    }
}