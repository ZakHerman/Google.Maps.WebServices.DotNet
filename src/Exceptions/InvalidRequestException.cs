namespace Google.Maps.WebServices.Exceptions;

/// <summary>
/// Indicates that the Web Service received a malformed request.
/// </summary>
public class InvalidRequestException : GoogleMapsException
{
    /// <summary>
    /// Constructs an instance of the <see cref="InvalidRequestException" /> class.
    /// </summary>
    /// <param name="errorMessage">The message that describes the error.</param>
    public InvalidRequestException(string errorMessage) : base(errorMessage)
    { }
}