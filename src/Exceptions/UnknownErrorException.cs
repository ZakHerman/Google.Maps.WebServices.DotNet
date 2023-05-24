namespace Google.Maps.WebServices.Exceptions;

/// <summary>
/// Indicates that the server encountered an unknown error. In some cases these are safe to retry.
/// </summary>
public class UnknownErrorException : GoogleMapsException
{
    /// <summary>
    /// Constructs an instance of the <see cref="UnknownErrorException" /> class.
    /// </summary>
    /// <param name="errorMessage">The message that describes the error.</param>
    public UnknownErrorException(string errorMessage) : base(errorMessage)
    { }
}