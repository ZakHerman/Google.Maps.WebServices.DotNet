using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.DistanceMatrix;

/// <summary>
/// A single result corresponding to an origin/destination pair in a <see
/// cref="DistanceMatrixRow" />.
/// </summary>
public class DistanceMatrixElement
{
    /// <summary>
    /// The total distance of this <see cref="DistanceMatrixElement" />
    /// </summary>
    [JsonProperty("distance")]
    public Distance Distance { get; set; }

    /// <summary>
    /// The total duration of this <see cref="DistanceMatrixElement" />.
    /// </summary>
    [JsonProperty("duration")]
    public Duration Duration { get; set; }

    /// <summary>
    /// The total duration of this <see cref="DistanceMatrixElement" />, based on current and
    /// historical traffic conditions.
    /// </summary>
    /// <remarks>
    /// <see cref="DurationInTraffic" /> will only be returned if all of the following are true:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// The request includes a 'departureTime' parameter set to a value within a few minutes of
    /// the current time.
    /// </description>
    /// </item>
    /// <item>
    /// <description>Traffic conditions are available for the requested route.</description>
    /// </item>
    /// <item>
    /// <description>The 'mode' parameter is set to driving.</description>
    /// </item>
    /// </list>
    /// </remarks>
    [JsonProperty("duration_in_traffic")]
    public Duration DurationInTraffic { get; set; }

    /// <summary>
    /// The status of the request for this origin/destination pair.
    /// </summary>
    [JsonProperty("status")]
    public DistanceMatrixElementStatus Status { get; set; }
}