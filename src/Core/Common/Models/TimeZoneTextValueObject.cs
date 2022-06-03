using Newtonsoft.Json;

namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// An object containing Unix time, a time zone, and its formatted text representation.
    /// </summary>
    public class TimeZoneTextValueObject
    {
        /// <summary>
        /// The time specified as a string in the time zone.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// The time zone. 
        /// </summary>
        /// <remarks>
        /// The value is the name of the time zone as defined in the IANA Time Zone Database.
        /// </remarks>
        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// The time specified as Unix time, or seconds since midnight, January 1, 1970 UTC.
        /// </summary>
        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
