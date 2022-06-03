using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions
{
    /// <summary>
    /// The total fare for the route.
    /// </summary>
    public class Fare
    {
        /// <summary>
        /// An ISO 4217 currency code indicating the currency that the amount is expressed in.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The total fare amount, formatted in the requested language.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// The total fare amount, in the currency specified.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
