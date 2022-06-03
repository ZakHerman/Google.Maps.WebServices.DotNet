using System.Collections.Generic;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions
{
    /// <summary>
    /// The transit line information.
    /// </summary>
    public class DirectionsTransitLine
    {
        /// <summary>
        /// The transit agency (or agencies) that operates this transit line.
        /// </summary>
        [JsonProperty("agencies")]
        public List<DirectionsTransitAgency> Agencies { get; } = new List<DirectionsTransitAgency>();

        /// <summary>
        /// The color commonly used in signage for this line.
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// The URL for the icon associated with this line.
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// The full name of this transit line.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The short name of this transit line.
        /// </summary>
        /// <remarks>
        /// This will normally be a line number, such as "M7" or "355".
        /// </remarks>
        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        /// <summary>
        /// The color commonly used in signage for this line.
        /// </summary>
        [JsonProperty("text_color")]
        public string TextColor { get; set; }

        /// <summary>
        /// The URL for this transit line as provided by the transit agency.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The type of vehicle that operates on this transit line.
        /// </summary>
        [JsonProperty("vehicle")]
        public DirectionsTransitVehicle Vehicle { get; set; }
    }
}
