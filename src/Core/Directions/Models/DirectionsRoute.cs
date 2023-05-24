using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions;

/// <summary>
/// A route consists of nested legs and steps.
/// </summary>
public class DirectionsRoute
{
    /// <summary>
    /// Contains the viewport bounding box of the <see cref="OverviewPolyline" />.
    /// </summary>
    [JsonProperty("bounds")]
    public Bounds Bounds { get; set; }

    /// <summary>
    /// Copyrights text to be displayed for this route.
    /// </summary>
    [JsonProperty("copyrights")]
    public string Copyrights { get; set; }

    /// <summary>
    /// The total fare (that is, the total ticket costs) on this route.
    /// </summary>
    /// <remarks>
    /// This property is only returned for transit requests and only for routes where fare information is
    /// available for all transit legs.
    /// </remarks>
    [JsonProperty("fare")]
    public Fare Fare { get; set; }

    /// <summary>
    /// Information about legs of the route, between two locations within the given route. A separate leg
    /// will be present for each waypoint or destination specified.
    /// </summary>
    /// <remarks>A route with no waypoints will contain exactly one leg within the legs collection.</remarks>
    [JsonProperty("legs")]
    public List<DirectionsLeg> Legs { get; private set; } = new();

    /// <summary>
    /// Contains an object that holds an encoded polyline representation of the route.
    /// This polyline is an approximate (smoothed) path of the resulting directions.
    /// </summary>
    [JsonProperty("overview_polyline")]
    public DirectionsPolyline OverviewPolyline { get; set; }

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
    public List<string> Warnings { get; private set; } = new();

    /// <summary>
    /// Indicates the order of any waypoints in the calculated route.
    /// </summary>
    /// <remarks>
    /// The waypoints may be reordered if the request was passed <c>optimize:true</c> within its
    /// <c>waypoints</c> parameter.
    /// </remarks>
    [JsonProperty("waypoint_order")]
    public List<int> WaypointOrder { get; private set; } = new();

    /// <summary>
    /// Merges two routes into one.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>A single <see cref="DirectionsRoute" />.</returns>
    public static DirectionsRoute Merge(DirectionsRoute a, DirectionsRoute b)
    {
        ArgumentNullException.ThrowIfNull(a, nameof(a));
        ArgumentNullException.ThrowIfNull(b, nameof(b));

        return new DirectionsRoute
        {
            Bounds = Bounds.Merge(a.Bounds, b.Bounds),
            Copyrights = a.Copyrights ?? b.Copyrights,
            Legs = a.Legs.Concat(b.Legs).ToList(),
            OverviewPolyline = DirectionsPolyline.Merge(a.OverviewPolyline, b.OverviewPolyline),
            Summary = a.Summary ?? b.Summary,
            Warnings = a.Warnings.Concat(b.Warnings).ToList(),
            WaypointOrder = a.WaypointOrder.Concat(b.WaypointOrder.Select(x => a.WaypointOrder.Max() + x + 1)).ToList()
        };
    }

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
}
