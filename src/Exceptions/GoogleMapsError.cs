using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Exceptions
{
    /// <summary>
    /// A standard format error.
    /// </summary>
    /// <remarks>
    /// The response body will be returned and the HTTP status code will be set to an error status.
    /// </remarks>
    public class GoogleMapsError
    {
        /// <summary>
        /// The HTTP status code of the response.
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// A short description of the error.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// A status code indicating the nature of the error.
        /// </summary>
        [JsonProperty("status")]
        public ApiResponseStatus ResponseStatus { get; set; }
    }
}
