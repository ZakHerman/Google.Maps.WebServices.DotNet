using System;
using System.Collections.Generic;
using Google.Maps.WebServices.Common;

namespace Google.Maps.WebServices.Roads;

/// <summary>
/// A request builder class for the Google Maps Nearest Roads Web Service.
/// </summary>
public class NearestRoadsRequestOptions : GoogleMapsRequestOptions<NearestRoadsRequestOptions>
{
    private const string RoadsUrlHost = "https://roads.googleapis.com";
    private const string RoadsUrlPath = "/v1/nearestRoads";

    /// <summary>
    /// Constructs an instance of the <see cref="NearestRoadsRequestOptions" /> class.
    /// </summary>
    public NearestRoadsRequestOptions() : base(RoadsUrlHost, RoadsUrlPath)
    { }

    /// <summary>
    /// Constructs an instance of the <see cref="NearestRoadsRequestOptions" /> class.
    /// </summary>
    /// <param name="points">The location points to process.</param>
    internal NearestRoadsRequestOptions(IEnumerable<LatLngLiteral> points) : base(RoadsUrlHost, RoadsUrlPath)
    {
        ArgumentNullException.ThrowIfNull(points, nameof(points));

        SetPoints(points);
    }

    internal NearestRoadsRequestOptions SetPoints(IEnumerable<LatLngLiteral> points)
    {
        return SetQueryParameter("points", string.Join("|", points));
    }
}
