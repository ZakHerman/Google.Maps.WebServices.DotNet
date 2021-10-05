namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// Represents the response of Google Maps Web Service operation.
    /// </summary>
    /// <typeparam name="T">The type of returned Google Maps result.</typeparam>
    public class GoogleMapsResponse<T> : IResponse<T>
    {
        /// <summary>
        /// Constructs an instance of the <see cref="GoogleMapsResponse{T}" /> class.
        /// </summary>
        /// <param name="response"></param>
        internal GoogleMapsResponse(IResponse<T> response)
        {
            ErrorMessage = response.ErrorMessage;
            IsSuccessful = response.IsSuccessful;
            ResponseStatus = response.ResponseStatus;
            Result = response.Result;
        }

        /// <inheritdoc />
        public string ErrorMessage { get; }

        /// <inheritdoc />
        public bool IsSuccessful { get; }

        /// <inheritdoc />
        public ApiResponseStatus ResponseStatus { get; }

        /// <inheritdoc />
        public T Result { get; }

        /// <summary>
        /// Returns the value of this <see cref="GoogleMapsResponse{T}" /> object.
        /// </summary>
        /// <param name="response">The <see cref="GoogleMapsResponse{T}" /> instance.</param>
        public static implicit operator T(GoogleMapsResponse<T> response) => response.Result;
    }
}
