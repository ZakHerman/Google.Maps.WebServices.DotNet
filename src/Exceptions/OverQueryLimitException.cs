namespace Google.Maps.WebServices.Exceptions;

/// <summary>
/// Indicates that the requesting account has exceeded its short-term quota.
/// </summary>
public class OverQueryLimitException : GoogleMapsException
{
    /// <summary>
    /// Constructs an instance of the <see cref="OverQueryLimitException" /> class.
    /// </summary>
    /// <param name="errorMessage">The message that describes the error.</param>
    public OverQueryLimitException(string errorMessage) : base(errorMessage)
    { }
}