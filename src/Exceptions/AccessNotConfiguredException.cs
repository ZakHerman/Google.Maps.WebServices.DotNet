namespace Google.Maps.WebServices.Exceptions;

/// <summary>
/// Indicates that the Web Service call was not configured for the supplied credentials and
/// environmental conditions.
/// </summary>
public class AccessNotConfiguredException : GoogleMapsException
{
    /// <summary>
    /// Constructs an instance of the <see cref="AccessNotConfiguredException" /> class.
    /// </summary>
    /// <param name="errorMessage">The message that describes the error.</param>
    public AccessNotConfiguredException(string errorMessage) : base(errorMessage)
    { }
}