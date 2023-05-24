using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions;

/// <summary>
/// Directions via waypoints.
/// </summary>
public class DirectionsViaWaypoint
{
    /// <summary>
    /// The location of the waypoint.
    /// </summary>
    [JsonProperty("location")]
    public LatLngLiteral Location { get; set; }

    /// <summary>
    /// The index of the step containing the waypoint.
    /// </summary>
    [JsonProperty("step_index")]
    public int StepIndex { get; set; }

    /// <summary>
    /// The position of the waypoint along the step's polyline, expressed as a ratio from 0 to 1.
    /// </summary>
    [JsonProperty("step_interpolation")]
    public double StepInterpolation { get; set; }
}
