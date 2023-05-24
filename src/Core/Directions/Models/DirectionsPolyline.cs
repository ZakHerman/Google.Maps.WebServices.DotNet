using System;
using System.Collections.Generic;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Utils;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions;

/// <summary>
/// Contains an object that holds an encoded polyline representation of the route.
/// </summary>
/// <remarks>
/// See <see
/// href="https://developers.google.com/maps/documentation/directions/get-directions#DirectionsPolyline">Encoded
/// DirectionsPolyline</see> for more detail.
/// </remarks>
public class DirectionsPolyline
{
    /// <summary>
    /// A single string representation of the polyline.
    /// </summary>
    [JsonProperty("points")]
    public string Points { get; set; }

    /// <summary>
    /// Merge two or more poly lines.
    /// </summary>
    /// <param name="encodedPolylines">A collection of polylines.</param>
    /// <returns>A single <see cref="DirectionsPolyline" />.</returns>
    public static DirectionsPolyline Merge(params DirectionsPolyline[] encodedPolylines)
    {
        ArgumentNullException.ThrowIfNull(encodedPolylines, nameof(encodedPolylines));

        List<LatLngLiteral> points = new();

        foreach (DirectionsPolyline encodedPolyline in encodedPolylines)
        {
            if (encodedPolyline?.Points != null)
                points.AddRange(PolylineEncoding.Decode(encodedPolyline.Points));
        }

        return new DirectionsPolyline
        {
            Points = PolylineEncoding.Encode(points)
        };
    }

    /// <inheritdoc />
    public override string ToString() => $"[{nameof(DirectionsPolyline)}: {Points}]";
}
