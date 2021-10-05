using System.Collections.Generic;
using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Geocoding
{
    /// <summary>
    /// <see cref="GeocodingServiceResponse" /> represents the the Google Maps Geocoding Web Service response.
    /// </summary>
    public class GeocodingServiceResponse : IResponse<IEnumerable<GeocodingResult>>
    {
        /// <inheritdoc />
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        /// <inheritdoc />
        public bool IsSuccessful => ResponseStatus == ApiResponseStatus.Ok || ResponseStatus == ApiResponseStatus.ZeroResults;

        /// <inheritdoc />
        [JsonProperty("status")]
        public ApiResponseStatus ResponseStatus { get; set; }

        /// <inheritdoc />
        public IEnumerable<GeocodingResult> Result => GeocodingResults;

        [JsonProperty("results")]
        private IEnumerable<GeocodingResult> GeocodingResults { get; } = new List<GeocodingResult>();
    }
}
