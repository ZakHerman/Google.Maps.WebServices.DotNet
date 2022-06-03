using System.Collections.Generic;
using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions
{
    /// <summary>
    /// <see cref="DirectionsServiceResponse" /> represents the the Google Maps Directions Web
    /// Service response.
    /// </summary>
    public class DirectionsServiceResponse : IResponse<DirectionsResult>
    {
        /// <inheritdoc />
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        /// <inheritdoc />
        public bool IsSuccessful => ResponseStatus == ApiResponseStatus.Ok;

        /// <inheritdoc />
        [JsonProperty("status")]
        public ApiResponseStatus ResponseStatus { get; set; }

        /// <inheritdoc />
        public DirectionsResult Result => new DirectionsResult(AvailableTravelModes, GeocodedWaypoints, Routes);

        [JsonProperty("available_travel_modes")]
        private List<TravelMode> AvailableTravelModes { get; } = new List<TravelMode>();

        [JsonProperty("geocoded_waypoints")]
        private List<DirectionsGeocodedWaypoint> GeocodedWaypoints { get; } = new List<DirectionsGeocodedWaypoint>();

        [JsonProperty("routes")]
        private List<DirectionsRoute> Routes { get; } = new List<DirectionsRoute>();
    }
}
