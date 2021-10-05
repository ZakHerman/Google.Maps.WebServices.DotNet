using System.Text;
using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Geocoding
{
    /// <summary>
    /// The geometry of a <see cref="GeocodingResult" />.
    /// </summary>
    public class Geometry
    {
        /// <summary>
        /// The geocoded <see cref="LatLng" />.
        /// </summary>
        [JsonProperty("location")]
        public LatLng Location { get; set; }

        /// <summary>
        /// The level of certainty of this <see cref="GeocodingResult" />.
        /// </summary>
        [JsonProperty("location_type")]
        public LocationType LocationType { get; set; }

        /// <summary>
        /// The recommended viewport for displaying the returned result.
        /// </summary>
        /// <remarks>
        /// Generally the viewport is used to frame a result when displaying it to a user.
        /// </remarks>
        [JsonProperty("viewport")]
        public Bounds ViewPort { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder($"[{nameof(Geometry)}: ");

            sb.Append($" {nameof(Location)} = {Location}");
            sb.Append($", {nameof(LocationType)} = {LocationType}");
            sb.Append($", {nameof(ViewPort)} = {ViewPort}");

            return sb.Append(']').ToString();
        }
    }
}
