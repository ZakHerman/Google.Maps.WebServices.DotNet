using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Extensions;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions
{
    /// <summary>
    /// A Directions API result. When the Directions API returns results, it places them within a
    /// routes array. Even if the service returns no results (such as if the origin and/or
    /// destination doesn't exist) it still returns an empty routes array.
    /// </summary>
    /// <remarks>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/directions/get-directions#Routes">Routes</see>
    /// for more detail.
    /// </remarks>
    public class DirectionsRoute
    {
        /// <summary>
        /// The viewport bounding box of the route.
        /// </summary>
        [JsonProperty("bounds")]
        public Bounds Bounds { get; set; }

        /// <summary>
        /// Copyrights text to be displayed for this route.
        /// </summary>
        [JsonProperty("copyrights")]
        public string Copyrights { get; set; }

        /// <summary>
        /// Information about legs of the route, between locations within the route. A separate leg
        /// will be present for each waypoint or destination specified.
        /// </summary>
        /// <remarks>A route with no waypoints will contain exactly one leg within the legs collection.</remarks>
        [JsonProperty("legs")]
        public List<DirectionsLeg> Legs { get; private set; } = new List<DirectionsLeg>();

        /// <summary>
        /// An approximate (smoothed) path of the resulting directions.
        /// </summary>
        [JsonProperty("overview_polyline")]
        public EncodedPolyline OverviewPolyline { get; set; }

        /// <summary>
        /// A short textual description for the route, suitable for naming and disambiguating the
        /// route from alternatives.
        /// </summary>
        [JsonProperty("summary")]
        public string Summary { get; set; }

        /// <summary>
        /// Warnings to be displayed when showing these directions.
        /// </summary>
        [JsonProperty("warnings")]
        public List<string> Warnings { get; private set; } = new List<string>();

        /// <summary>
        /// Indicates the order of any waypoints in the calculated route.
        /// </summary>
        /// <remarks>
        /// The waypoints may be reordered if the request was passed <c>optimize:true</c> within its
        /// <c>waypoints</c> parameter.
        /// </remarks>
        [JsonProperty("waypoint_order")]
        public List<int> WaypointOrder { get; private set; } = new List<int>();

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder($"[{nameof(DirectionsRoute)}:");

            sb.Append($" {nameof(Summary)} = {Summary}");
            sb.Append($", {Legs.Count} {nameof(Legs)}");
            sb.Append($", {nameof(WaypointOrder)} = [").AppendJoin(", ", WaypointOrder).Append(']');
            sb.Append($", {nameof(Bounds)} = {Bounds}");

            if (Warnings.Count > 0)
                sb.Append($", {Warnings.Count} {nameof(Warnings)}");

            return sb.Append(']').ToString();
        }

        internal static DirectionsRoute Merge(DirectionsRoute a, DirectionsRoute b)
        {
            if (a is null)
                throw new ArgumentNullException(nameof(a));

            if (b is null)
                throw new ArgumentNullException(nameof(b));

            return new DirectionsRoute
            {
                Bounds = Bounds.Merge(a.Bounds, b.Bounds),
                Copyrights = a.Copyrights ?? b.Copyrights,
                Legs = a.Legs.Concat(b.Legs).ToList(),
                OverviewPolyline = EncodedPolyline.Merge(a.OverviewPolyline, b.OverviewPolyline),
                Summary = a.Summary ?? b.Summary,
                Warnings = a.Warnings.Concat(b.Warnings).ToList(),
                WaypointOrder = a.WaypointOrder.Concat(b.WaypointOrder.Select(x => a.WaypointOrder.Max() + x + 1)).ToList()
            };
        }
    }
}
