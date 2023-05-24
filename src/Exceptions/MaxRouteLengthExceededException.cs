namespace Google.Maps.WebServices.Exceptions;

/// <summary>
/// Indicates that the requested route is too long and cannot be processed.
/// </summary>
/// <remarks>
/// This error occurs when more complex directions are returned. Try reducing the number of
/// waypoints, turns, or instructions. See <see
/// href="https://developers.google.com/maps/documentation/directions/get-directions#StatusCodes">Status
/// Codes</see> for more detail.
/// </remarks>
public class MaxRouteLengthExceededException : GoogleMapsException
{
    /// <summary>
    /// Constructs an instance of the <see cref="MaxRouteLengthExceededException" /> class.
    /// </summary>
    /// <param name="errorMessage">The message that describes the error.</param>
    public MaxRouteLengthExceededException(string errorMessage) : base(errorMessage)
    { }
}