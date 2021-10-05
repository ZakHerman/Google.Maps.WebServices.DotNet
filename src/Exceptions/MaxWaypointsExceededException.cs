namespace Google.Maps.WebServices.Exceptions
{
    /// <summary>
    /// Indicates that too many waypoints were provided in the request.
    /// </summary>
    /// <remarks>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/directions/get-directions#StatusCodes">Status
    /// Codes</see> for more detail.
    /// </remarks>
    public class MaxWaypointsExceededException : GoogleMapsException
    {
        /// <summary>
        /// Constructs an instance of the <see cref="MaxWaypointsExceededException" /> class.
        /// </summary>
        /// <param name="errorMessage">The message that describes the error.</param>
        public MaxWaypointsExceededException(string errorMessage) : base(errorMessage)
        { }
    }
}
