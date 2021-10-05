using Newtonsoft.Json;

namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// The duration component for Directions API results.
    /// </summary>
    public class Duration
    {
        /// <summary>
        /// The human-friendly duration.
        /// </summary>
        [JsonProperty("text")]
        public string DisplayValue { get; set; }

        /// <summary>
        /// The numeric duration, in seconds.
        /// </summary>
        [JsonProperty("value")]
        public long Seconds { get; set; }

        /// <inheritdoc />
        public override string ToString() => DisplayValue;
    }
}
