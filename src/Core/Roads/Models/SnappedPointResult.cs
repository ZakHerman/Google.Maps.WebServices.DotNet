using System.Text;
using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Roads
{
    /// <summary>
    /// A point that has been snapped to a road by the Snap to Roads Web Service.
    /// </summary>
    public class SnappedPointResult
    {
        /// <summary>
        /// A <see cref="LatLng" /> representing the snapped location.
        /// </summary>
        [JsonProperty("location")]
        public LatLng Location { get; set; }

        /// <summary>
        /// The index of the corresponding value in the original request.
        /// </summary>
        /// <remarks>
        /// Each value in the request should map to a snapped value in the response. However, if
        /// interpolate is set to true, then it's possible that the response will contain more
        /// coordinates than the request. Interpolated values will not have an originalIndex. These
        /// values are indexed from 0, so a point with an originalIndex of 4 will be the snapped
        /// value of the 5th <see cref="LatLng" /> passed to the path parameter.
        /// </remarks>
        [JsonProperty("originalIndex")]
        public int? OriginalIndex { get; set; }

        /// <summary>
        /// A unique identifier for a place.
        /// </summary>
        /// <remarks>
        /// All place ids returned by the Roads Web Service will correspond to road segments.
        /// </remarks>
        [JsonProperty("placeId")]
        public string PlaceId { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder($"[{nameof(SnappedPointResult)}:");

            sb.Append($" {nameof(Location)} = {Location}");
            sb.Append($", {nameof(PlaceId)} = {PlaceId}");

            if (OriginalIndex != null)
                sb.Append($", {nameof(OriginalIndex)} = {OriginalIndex}");

            return sb.Append(']').ToString();
        }
    }
}
