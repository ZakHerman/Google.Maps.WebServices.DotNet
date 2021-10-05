using System.Collections.Generic;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Exceptions;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Roads
{
    /// <summary>
    /// <see cref="SnapToRoadsServiceResponse" /> represents the the Google Maps Snap to Roads Web
    /// Service response.
    /// </summary>
    public class SnapToRoadsServiceResponse : IResponse<IEnumerable<SnappedPointResult>>
    {
        /// <inheritdoc />
        public string ErrorMessage => Error?.Message ?? WarningMessage;

        /// <inheritdoc />
        // TODO: Check for warning message
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
