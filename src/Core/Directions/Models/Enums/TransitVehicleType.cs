using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Google.Maps.WebServices.Directions;

/// <summary>
/// 
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum TransitVehicleType
{
    /// <summary>
    /// Indicates an unknown error.
    /// </summary>
    Unknown,

    /// <summary>
    /// A bus.
    /// </summary>
    [EnumMember(Value = "BUS")]
    Bus,

    /// <summary>
    /// A vehicle that operates on a cable, usually on the ground.
    /// </summary>
    /// <remarks>
    /// Aerial cable cars may be of the type <see cref="GondolaLift"/>.
    /// </remarks>
    [EnumMember(Value = "CABLE_CAR")]
    CableCar,

    /// <summary>
    /// Commuter rail.
    /// </summary>
    [EnumMember(Value = "COMMUTER_TRAIN")]
    CommuterTrain,

    /// <summary>
    /// A ferry.
    /// </summary>
    [EnumMember(Value = "FERRY")]
    Ferry,

    /// <summary>
    /// A vehicle that is pulled up a steep incline by a cable.
    /// </summary>
    /// <remarks>
    /// A Funicular typically consists of two cars, with each car acting as a counterweight for the other.
    /// </remarks>
    [EnumMember(Value = "FUNICULAR")]
    Funicular,

    /// <summary>
    /// An aerial cable car.
    /// </summary>
    [EnumMember(Value = "GONDOLA_LIFT")]
    GondolaLift,

    /// <summary>
    /// Heavy rail.
    /// </summary>
    [EnumMember(Value = "HEAVY_RAIL")]
    HeavyRail,

    /// <summary>
    /// High speed train.
    /// </summary>
    [EnumMember(Value = "HIGH_SPEED_TRAIN")]
    HighSpeedTrain,

    /// <summary>
    /// Intercity bus.
    /// </summary>
    [EnumMember(Value = "INTERCITY_BUS")]
    IntercityBus,

    /// <summary>
    /// Long distance train.
    /// </summary>
    [EnumMember(Value = "LONG_DISTANCE_TRAIN")]
    LongDistanceTrain,

    /// <summary>
    /// Light rail transit.
    /// </summary>
    [EnumMember(Value = "METRO_RAIL")]
    MetroRail,

    /// <summary>
    /// Monorail.
    /// </summary>
    [EnumMember(Value = "MONORAIL")]
    Monorail,

    /// <summary>
    /// All other vehicles will return this type.
    /// </summary>
    [EnumMember(Value = "OTHER")]
    Other,

    /// <summary>
    /// Rail.
    /// </summary>
    [EnumMember(Value = "RAIL")]
    Rail,

    /// <summary>
    /// Share taxi is a kind of bus with the ability to drop off and pick up passengers anywhere on its route.
    /// </summary>
    [EnumMember(Value = "SHARE_TAXI")]
    ShareTaxi,

    /// <summary>
    /// Underground light rail.
    /// </summary>
    [EnumMember(Value = "SUBWAY")]
    Subway,

    /// <summary>
    /// Above ground light rail.
    /// </summary>
    [EnumMember(Value = "TRAM")]
    Tram,

    /// <summary>
    /// Trolleybus.
    /// </summary>
    [EnumMember(Value = "TROLLEYBUS")]
    Trolleybus
}