namespace Google.Maps.WebServices.Exceptions
{
    /// <summary>
    /// Indicates that the Web Service denied the request.
    /// </summary>
    public class RequestDeniedException : GoogleMapsException
    {
        /// <summary>
        /// Constructs an instance of the <see cref="RequestDeniedException" /> class.
        /// </summary>
        /// <param name="errorMessage">The message that describes the error.</param>
        public RequestDeniedException(string errorMessage) : base(errorMessage)
        { }
    }
}
