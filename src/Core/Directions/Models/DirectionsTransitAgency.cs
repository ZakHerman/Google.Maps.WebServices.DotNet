using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions
{
    /// <summary>
    /// The transit agency.
    /// </summary>
    public class DirectionsTransitAgency
    {
        /// <summary>
        /// The name of this transit agency.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The transit agency's phone number.
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// The transit agency's URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
