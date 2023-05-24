using System.Runtime.Serialization;

namespace Google.Maps.WebServices.Common;

/// <summary>
/// Specifies traffic prediction model when requesting future directions.
/// </summary>
public enum TrafficModel
{
    /// <summary>
    /// Indicates that the returned 'duration_in_traffic' should be the best estimate of travel
    /// time given what is known about both historical traffic conditions and live traffic.
    /// </summary>
    /// <remarks>
    /// Live traffic becomes more important the closer the 'departure_time' is to now.
    /// </remarks>
    [EnumMember(Value = "best_guess")]
    BestGuess,

    /// <summary>
    /// Indicates that the returned 'duration_in_traffic' should be shorter than the actual
    /// travel time on most days, though occasional days with particularly good traffic
    /// conditions may be faster than this value.
    /// </summary>
    [EnumMember(Value = "optimistic")]
    Optimistic,

    /// <summary>
    /// Indicates that the returned 'duration_in_traffic' should be longer than the actual
    /// travel time on most days, though occasional days with particularly bad traffic
    /// conditions may exceed this value.
    /// </summary>
    [EnumMember(Value = "pessimistic")]
    Pessimistic
}