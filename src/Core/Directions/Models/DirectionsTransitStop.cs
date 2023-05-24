using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions;

/// <summary>
/// A transit stop.
/// </summary>
public class DirectionsTransitStop
{
    /// <summary>
    /// The location of the stop.
    /// </summary>
    [JsonProperty("location")]
    public LatLngLiteral Location { get; set; }

    /// <summary>
    /// The name of the transit stop.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
}