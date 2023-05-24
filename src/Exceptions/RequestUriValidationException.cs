using System;
using System.Collections.Generic;
using System.Linq;

namespace Google.Maps.WebServices.Exceptions;

/// <summary>
/// Indicates that there was an error with request validation.
/// </summary>
public class RequestUriValidationException : Exception
{
    /// <summary>
    /// Constructs an instance of the <see cref="RequestUriValidationException" /> class.
    /// </summary>
    /// <param name="validationFailures">A dictionary of validation failures.</param>
    public RequestUriValidationException(IDictionary<string, string> validationFailures) : base(BuildErrorMessage(validationFailures))
    { }

    private static string BuildErrorMessage(IDictionary<string, string> validationFailures)
    {
        IEnumerable<string> errors = validationFailures.Select(x => $"{Environment.NewLine} -- {x.Key}: {x.Value}");

        return "Validation failed: " + string.Join(string.Empty, errors);
    }
}