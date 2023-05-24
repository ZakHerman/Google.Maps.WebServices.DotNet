namespace Google.Maps.WebServices.Exceptions;

/// <summary>
/// Indicates that no results were returned.
/// </summary>
/// <remarks>
/// In some cases, this will be treated as a success state and you will only see an empty array.
/// For time zone data, it means that no time zone information could be found for the specified
/// position or time. Confirm that the request is for a location on land, and not over water.
/// </remarks>
public class ZeroResultsException : GoogleMapsException
{
    /// <summary>
    /// Constructs an instance of the <see cref="ZeroResultsException" /> class.
    /// </summary>
    /// <param name="errorMessage">The message that describes the error.</param>
    public ZeroResultsException(string errorMessage) : base(errorMessage)
    { }
}