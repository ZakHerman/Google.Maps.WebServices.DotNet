namespace Google.Maps.WebServices.Exceptions
{
    /// <summary>
    /// Indicates that the requesting account has exceeded its daily quota.
    /// </summary>
    public class OverDailyLimitException : GoogleMapsException
    {
        /// <summary>
        /// Constructs an instance of the <see cref="OverDailyLimitException" /> class.
        /// </summary>
        /// <param name="errorMessage">The message that describes the error.</param>
        public OverDailyLimitException(string errorMessage) : base(errorMessage)
        { }
    }
}
