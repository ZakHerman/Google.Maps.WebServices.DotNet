namespace Google.Maps.WebServices.Exceptions
{
    /// <summary>
    /// Indicates at least one of the locations specified in the request's origin, destination, or
    /// waypoints could not be geocoded.
    /// </summary>
    public class NotFoundException : GoogleMapsException
    {
        /// <summary>
        /// Constructs an instance of the <see cref="NotFoundException" /> class.
        /// </summary>
        /// <param name="errorMessage">The message that describes the error.</param>
        public NotFoundException(string errorMessage) : base(errorMessage)
        { }
    }
}
