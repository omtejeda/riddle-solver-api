using FluentValidation.Results;

namespace RiddleSolver.Core.Helpers;

/// <summary>
/// Provides helper methods for working with FluentValidation results.
/// </summary>
public static class ValidationResultHelper
{
    /// <summary>
    /// Retrieves the first error message from a FluentValidation <see cref="ValidationResult"/>.
    /// </summary>
    /// <param name="validationResult">The validation result containing error information.</param>
    /// <returns>The first error message if any exist; otherwise, an empty string.</returns>
    public static string GetFirstErrorMessage(this ValidationResult validationResult)
    {
        return validationResult
            .Errors
            .Select(x => x.ErrorMessage)
            .FirstOrDefault()
            ?? string.Empty;
    }
}