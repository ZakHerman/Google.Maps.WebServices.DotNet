using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions;

/// <summary>
/// Additional information that is not relevant for other modes of transportation.
/// </summary>
public class DirectionsTransitDetails
{
    /// <summary>
    /// The arrival transit stop.
    /// </summary>
    [JsonProperty("arrival_stop")]
    public DirectionsTransitStop ArrivalStop { get; set; }

    /// <summary>
    /// The arrival time of the transit stop.
    /// </summary>
    [JsonProperty("arrival_time")]
    public TimeZoneTextValueObject ArrivalTime { get; set; }

    /// <summary>
    /// The departure transit stop.
    /// </summary>
    [JsonProperty("departure_stop")]
    public DirectionsTransitStop DepartureStop { get; set; }

    /// <summary>
    /// The departure time of the transit stop.
    /// </summary>
    [JsonProperty("departure_time")]
    public TimeZoneTextValueObject DepartureTime { get; set; }

    /// <summary>
    /// Specifies the direction in which to travel on this line, as it is marked on the vehicle or at the departure stop.
    /// </summary>
    /// <remarks>
    /// This will often be the terminus station.
    /// </remarks>
    [JsonProperty("headsign")]
    public string HeadSign { get; set; }

    /// <summary>
    /// Specifies the expected number of seconds between departures from the same stop at this time.
    /// </summary>
    /// <remarks>
    /// This will often be the terminus station.
    /// </remarks>
    [JsonProperty("headway")]
    public int HeadWay { get; set; }

    /// <summary>
    /// Contains information about the transit line used in this step.
    /// </summary>
    [JsonProperty("line")]
    public DirectionsTransitLine Line { get; set; }

    /// <summary>
    /// The number of stops from the departure to the arrival stop.
    /// </summary>
    /// <remarks>
    /// This includes the arrival stop, but not the departure stop.
    /// For example, if your directions involve leaving from Stop A,
    /// passing through stops B and C, and arriving at stop D,
    /// num_stops will return 3.
    /// </remarks>
    [JsonProperty("num_stops")]
    public DirectionsTransitLine NumberOfStops { get; set; }

    /// <summary>
    /// The text that appears in schedules and sign boards to identify
    /// a transit trip to passengers.
    /// </summary>
    /// <remarks>
    /// The text should uniquely identify a trip within a service day.
    /// For example, "538" is the trip_short_name of the Amtrak train
    /// that leaves San Jose, CA at 15:10 on weekdays to Sacramento, CA.
    /// </remarks>
    [JsonProperty("trip_short_name")]
    public DirectionsTransitLine TripName { get; set; }
}