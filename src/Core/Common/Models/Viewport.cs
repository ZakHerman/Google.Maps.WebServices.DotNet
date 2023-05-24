using Newtonsoft.Json;

namespace Google.Maps.WebServices.Common;

/// <summary>
/// A latitude-longitude viewport, represented as two diagonally opposite low and high points.
/// </summary>
/// <remarks>
/// A viewport is considered a closed region, i.e. it includes its boundary.
/// </remarks>
public class Viewport
{
    /// <summary>
    /// The high point of the viewport.
    /// </summary>
    [JsonProperty("high")]
    public LatLngLiteral High { get; set; }

    /// <summary>
    /// The low point of the viewport.
    /// </summary>
    [JsonProperty("low")]
    public LatLngLiteral Low { get; set; }
}