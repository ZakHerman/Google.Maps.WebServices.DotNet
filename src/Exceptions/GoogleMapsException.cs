using System;
using Google.Maps.WebServices.Common;

namespace Google.Maps.WebServices.Exceptions
{
    /// <summary>
    /// <see cref="GoogleMapsException" /> and its descendants represent an error returned by the
    /// remote Web Service.
    /// </summary>
    /// <remarks>
    /// Web Service exceptions are determined by the <c>Status</c> field returned in any of the
    /// Google Maps responses.
    /// </remarks>
    public class GoogleMapsException : Exception
    {
        /// <summary>
        /// Constructs an instance of the <see cref="GoogleMapsException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        protected GoogleMapsException(string message) : base(message)
        { }

        /// <summary>
        /// Construct the appropriate <see cref="GoogleMapsException" /> from the response. If the
        /// response was successful, this method will return null.
        /// </summary>
        /// <param name="status">The status field returned from the Web Service.</param>
        /// <param name="errorMessage">The message that describes the error.</param>
        public static void Create(ApiResponseStatus status, string errorMessage)
        {
            switch (status)
            {
                case ApiResponseStatus.Ok:
                    break;

                case ApiResponseStatus.NotFound:
                    throw new NotFoundException(errorMessage);

                case ApiResponseStatus.ZeroResults:
                    throw new ZeroResultsException(errorMessage);

                case ApiResponseStatus.MaxWaypointsExceeded:
                    throw new MaxWaypointsExceededException(errorMessage);

                case ApiResponseStatus.MaxRouteLengthExceeded:
                    throw new MaxRouteLengthExceededException(errorMessage);

                case ApiResponseStatus.Invalid:
                case ApiResponseStatus.InvalidRequest:
                case ApiResponseStatus.InvalidArgument:
                case ApiResponseStatus.ParseError:
                    throw new InvalidRequestException(errorMessage);

                case ApiResponseStatus.OverDailyLimit:
                case ApiResponseStatus.DailyLimitExceeded:
                    throw new OverDailyLimitException(errorMessage);

                case ApiResponseStatus.OverQueryLimit:
                case ApiResponseStatus.ResourceExhausted:
                case ApiResponseStatus.UserRateLimitExceeded:
                    throw new OverQueryLimitException(errorMessage);

                case ApiResponseStatus.RequestDenied:
                case ApiResponseStatus.PermissionDenied:
                    throw new RequestDeniedException(errorMessage);

                case ApiResponseStatus.MaxElementsExceeded:
                case ApiResponseStatus.MaxDimensionsExceeded:
                    throw new MaxElementsExceededException(errorMessage);

                case ApiResponseStatus.AccessNotConfigured:
                case ApiResponseStatus.KeyInvalid:
                    throw new AccessNotConfiguredException(errorMessage);

                case ApiResponseStatus.ResultsNotFound:
                    break;

                default:
                    throw new UnknownErrorException($"An unexpected error occurred. Status: {status}, Message: {errorMessage}");
            }
        }
    }
}
