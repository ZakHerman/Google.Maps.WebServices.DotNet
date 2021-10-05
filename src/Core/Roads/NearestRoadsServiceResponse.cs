using System.Collections.Generic;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Exceptions;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Roads
{
    /// <summary>
    /// <see cref="NearestRoadsServiceResponse" /> represents the the Google Maps Nearest Roads Web
    /// Service response.
    /// </summary>
    public class NearestRoadsServiceResponse : IResponse<IEnumerable<SnappedPointResult>>
    {
        /// <inheritdoc />
        public string ErrorMessage => Error?.Message ?? WarningMessage;

        /// <inheritdoc />
        public bool IsSuccessful => ResponseStatus == ApiResponseStatus.Ok;

        /// <inheritdoc />
        public ApiResponseStatus ResponseStatus => Error?.ResponseStatus ?? ApiResponseStatus.Ok;

        /// <inheritdoc />
        public IEnumerable<SnappedPointResult> Result => SnappedPoints;

        [JsonProperty("error")]
        private GoogleMapsError Error { get; set; }

        [JsonProperty("snappedPoints")]
        private IEnumerable<SnappedPointResult> SnappedPoints { get; } = new List<SnappedPointResult>();

        /// <summary>
        /// A string containing a user-visible warning.
        /// </summary>
        [JsonProperty("warningMessage")]
        private string WarningMessage { get; set; }
    }
}
