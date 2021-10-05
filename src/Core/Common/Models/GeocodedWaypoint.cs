using System.Collections.Generic;
using System.Text;
using Google.Maps.WebServices.Extensions;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// A point in a Directions API response; either the origin, one of the requested waypoints, or
    /// the destination.
    /// </summary>
    /// <remarks>
    /// See <a
    /// href="https://developers.google.com/maps/documentation/directions/get-directions#GeocodedWaypoints">Geocoded
    /// Waypoints</a> for more detail.
    /// </remarks>
    public class GeocodedWaypoint
    {
        /// <summary>
        /// The status code resulting from the geocoding operation for this waypoint.
        /// </summary>
        [JsonProperty("geocoder_status")]
        public GeocodedWaypointStatus GeoCoderStatus { get; set; }

        /// <summary>
        /// Indicates that the geocoder did not return an exact match for the original request,
        /// though it was able to match part of the requested address.
        /// </summary>
        [JsonProperty("partial_match")]
        public bool PartialMatch { get; set; }

        /// <summary>
        /// A unique identifier for this waypoint that can be used with other Google APIs.
        /// </summary>
        /// <remarks>
        /// See <a
        /// href="https://developers.google.com/maps/documentation/places/web-service/place-id">Place
        /// IDs</a> for more detail.
        /// </remarks>
        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        /// <summary>
        /// The address types of the geocoding result used for calculating directions.
        /// </summary>
        [JsonProperty("types")]
        public List<AddressType> Types { get; } = new List<AddressType>();

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder($"[{nameof(GeocodedWaypoint)}:");

            sb.Append($" {nameof(GeoCoderStatus)} = {GeoCoderStatus}");
            sb.Append($", {nameof(PartialMatch)} = {PartialMatch}");
            sb.Append($", {nameof(PlaceId)} = {PlaceId}");
            sb.Append($", {nameof(Types)} = [").AppendJoin(", ", Types).Append(']');

            return sb.Append(']').ToString();
        }
    }
}
