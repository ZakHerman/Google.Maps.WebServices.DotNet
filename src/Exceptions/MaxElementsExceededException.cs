namespace Google.Maps.WebServices.Exceptions
{
    /// <summary>
    /// Indicates that the product of origins and destinations exceeds the per-query limit.
    /// </summary>
    /// <remarks>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/distance-matrix/usage-and-billing">Distance
    /// Matrix API Usage and Billing</see> for more detail.
    /// </remarks>
    public class MaxElementsExceededException : GoogleMapsException
    {
        /// <summary>
        /// Constructs an instance of the <see cref="MaxElementsExceededException" /> class.
        /// </summary>
        /// <param name="errorMessage">The message that describes the error.</param>
        public MaxElementsExceededException(string errorMessage) : base(errorMessage)
        { }
    }
}
