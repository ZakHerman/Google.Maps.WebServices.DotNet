using System.Runtime.Serialization;

namespace Google.Maps.WebServices.Common;

/// <summary>
/// Directions may be calculated that adhere to certain restrictions.
/// </summary>
/// <remarks>
/// See <see
/// href="https://developers.google.com/maps/documentation/directions/get-directions#Restrictions">Directions
/// Restrictions</see> for more detail.
/// </remarks>
public enum RouteRestriction
{
    /// <summary>
    /// Indicates that the calculated route should avoid toll roads/bridges.
    /// </summary>
    [EnumMember(Value = "tolls")]
    Tolls,

    /// <summary>
    /// Indicates that the calculated route should avoid highways.
    /// </summary>
    [EnumMember(Value = "highways")]
    Highways,

    /// <summary>
    /// Indicates that the calculated route should avoid ferries.
    /// </summary>
    [EnumMember(Value = "ferries")]
    Ferries,

    /// <summary>
    /// Indicates that the calculated route should avoid indoor areas.
    /// </summary>
    [EnumMember(Value = "indoor")]
    Indoor
}