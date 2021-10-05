using Newtonsoft.Json;

namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// The distance component for Directions API results.
    /// </summary>
    public class Distance
    {
        /// <summary>
        /// The human-friendly distance.
        /// </summary>
        /// <remarks>
        /// This is rounded and in an appropriate unit for the request. The units can be overridden
        /// with a request parameter.
        /// </remarks>
        [JsonProperty("text")]
        public string DisplayValue { get; set; }

        /// <summary>
        /// The numeric distance, in meters.
        /// </summary>
        [JsonProperty("value")]
        public long Meters { get; set; }

        /// <inheritdoc />
        public override string ToString() => DisplayValue;
    }
}
