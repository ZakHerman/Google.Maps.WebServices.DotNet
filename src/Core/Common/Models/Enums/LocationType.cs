using System.Runtime.Serialization;

namespace Google.Maps.WebServices.Common;

/// <summary>
/// Location types for a reverse geocoding request.
/// </summary>
/// <remarks>
/// See <see
/// href="https://developers.google.com/maps/documentation/geocoding/start#reverse">Reverse
/// Geocoding</see> for more detail.
/// </remarks>
public enum LocationType
{
    /// <summary>
    /// Indicates an unknown location type returned by the server.
    /// </summary>
    [EnumMember(Value = "UNKNOWN")]
    Unknown,

    /// <summary>
    /// Restricts the results to addresses for which we have location information accurate down
    /// to street address precision.
    /// </summary>
    [EnumMember(Value = "ROOFTOP")]
    Rooftop,

    /// <summary>
    /// Restricts the results to those that reflect an approximation (usually on a road)
    /// interpolated between two precise points (such as intersections). An interpolated range
    /// generally indicates that rooftop geocodes are unavailable for a street address.
    /// </summary>
    [EnumMember(Value = "RANGE_INTERPOLATED")]
    RangeInterpolated,

    /// <summary>
    /// Restricts the results to geometric centers of a location such as a polyline (for
    /// example, a street) or polygon (region).
    /// </summary>
    [EnumMember(Value = "GEOMETRIC_CENTER")]
    GeometricCenter,

    /// <summary>
    /// Restricts the results to those that are characterized as approximate.
    /// </summary>
    [EnumMember(Value = "APPROXIMATE")]
    Approximate
}