using System.Collections.Generic;
using System.Text;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Extensions;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions
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
    public class DirectionsGeocodedWaypoint
    {
        /// <summary>
        /// Indicates the status code resulting from the geocoding operation. 
        /// </summary>
        [JsonProperty("geocoder_status")]
        public GeocodedWaypointStatus GeocoderStatus { get; set; }

        /// <summary>
        /// Indicates that the geocoder did not return an exact match for the original request,
        /// though it was able to match part of the requested address.
        /// </summary>
        /// <remarks>
        /// Partial matches most often occur for street addresses that do not exist within the
        /// locality you pass in the request. Partial matches may also be returned when a request
        /// matches two or more locations in the same locality. 
        /// </remarks>
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
        /// <remarks>
        /// An empty collection of address types indicates there are no known types for the
        /// particular address component.
        /// </remarks>
        [JsonProperty("types")]
        public List<AddressType> Types { get; } = new List<AddressType>();

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder($"[{nameof(DirectionsGeocodedWaypoint)}:");

            sb.Append($" {nameof(GeocoderStatus)} = {GeocoderStatus}");
            sb.Append($", {nameof(PartialMatch)} = {PartialMatch}");
            sb.Append($", {nameof(PlaceId)} = {PlaceId}");
            sb.Append($", {nameof(Types)} = [").AppendJoin(", ", Types).Append(']');

            return sb.Append(']').ToString();
        }
    }
}
