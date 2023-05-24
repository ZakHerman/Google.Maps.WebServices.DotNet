using System.Collections.Generic;
using System.Text;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Utils;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions;

/// <summary>
/// A component of a Directions API result.
/// </summary>
/// <remarks>
/// See <see
/// href="https://developers.google.com/maps/documentation/directions/get-directions#Legs">Legs
/// documentation</see> for more detail.
/// </remarks>
public class DirectionsLeg
{
    /// <summary>
    /// The estimated time of arrival for this leg.
    /// </summary>
    /// <remarks>
    /// This property is only returned for transit directions.
    /// </remarks>
    [JsonProperty("arrival_time")]
    public TimeZoneTextValueObject ArrivalTime { get; set; }

    /// <summary>
    /// The estimated time of departure for this leg.
    /// </summary>
    /// <remarks>
    /// This property is only returned for transit directions.
    /// </remarks>
    [JsonProperty("departure_time")]
    public TimeZoneTextValueObject DepartureTime { get; set; }

    /// <summary>
    /// The total distance covered by this leg.
    /// </summary>
    [JsonProperty("distance")]
    public Distance Distance { get; set; }

    /// <summary>
    /// The total duration of this leg.
    /// </summary>
    [JsonProperty("duration")]
    public Duration Duration { get; set; }

    /// <summary>
    /// The total duration of this leg, taking into account current traffic conditions.
    /// </summary>
    /// <remarks>
    /// The duration in traffic will only be returned if all of the following are true:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// The directions request includes a departureTime parameter set to a value within a few
    /// minutes of the current time.
    /// </description>
    /// </item>
    /// <item>
    /// <description>Traffic conditions are available for the requested route.</description>
    /// </item>
    /// <item>
    /// <description>The directions request does not include stopover waypoints.</description>
    /// </item>
    /// </list>
    /// </remarks>
    [JsonProperty("duration_in_traffic")]
    public Duration DurationInTraffic { get; set; }

    /// <summary>
    /// The human-readable address (typically a street address) from reverse geocoding
    /// the <see cref="EndLocation" /> of this leg.
    /// </summary>
    [JsonProperty("end_address")]
    public string EndAddress { get; set; }

    /// <summary>
    /// The latitude/longitude coordinates of the given destination of this leg.
    /// </summary>
    /// <remarks>
    /// Because the Directions API calculates directions between locations by using the nearest
    /// transportation option (usually a road) at the start and end points,
    /// <see cref="EndLocation" /> may be different than the provided destination of this leg
    /// if, for example, a road is not near the destination.
    /// </remarks>
    [JsonProperty("end_location")]
    public LatLngLiteral EndLocation { get; set; }

    /// <summary>
    /// The human-readable address (typically a street address) resulting from reverse geocoding
    /// the <see cref="StartLocation" /> of this leg.
    /// </summary>
    [JsonProperty("start_address")]
    public string StartAddress { get; set; }

    /// <summary>
    /// The latitude/longitude coordinates of the origin of this leg.
    /// </summary>
    /// <remarks>
    /// Because the Directions API calculates directions between locations by using the nearest
    /// transportation option (usually a road) at the start and end points, StartLocation may be
    /// different from the provided origin of this leg if, for example, a road is not near the origin.
    /// </remarks>
    [JsonProperty("start_location")]
    public LatLngLiteral StartLocation { get; set; }

    /// <summary>
    /// Contains a collection of steps denoting information about each separate step of this leg
    /// of the journey.
    /// </summary>
    [JsonProperty("steps")]
    public List<DirectionsStep> Steps { get; } = new();

    /// <summary>
    /// The locations of via waypoints along this leg.
    /// </summary>
    [JsonProperty("via_waypoint")]
    public List<DirectionsViaWaypoint> ViaWaypoints { get; } = new();

    /// <summary>
    /// Decodes the <see cref="DirectionsPolyline" /> of <see cref="Steps" />.
    /// </summary>
    /// <returns>A collection of <see cref="LatLngLiteral" />.</returns>
    public IEnumerable<LatLngLiteral> GetPath()
    {
        var path = new List<LatLngLiteral>();

        foreach (DirectionsStep directionsStep in Steps)
        {
            string encodedPath = directionsStep?.PolyLine?.Points;

            if (encodedPath != null)
                path.AddRange(PolylineEncoding.Decode(encodedPath));
        }

        return path;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        var sb = new StringBuilder($"[{nameof(DirectionsLeg)}:");

        sb.Append($" {StartAddress} -> {EndAddress} ({StartLocation} -> {EndLocation})");
        sb.Append($", {nameof(Duration)} = {Duration}");
        sb.Append($", {nameof(Distance)} = {Distance}");

        if (DurationInTraffic != null)
            sb.Append($", {nameof(DurationInTraffic)} = {DurationInTraffic}");

        sb.Append($", {Steps.Count} {nameof(Steps)}");

        return sb.Append(']').ToString();
    }
}
