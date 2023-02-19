using Newtonsoft.Json;

namespace Google.Maps.WebServices.AddressValidation
{
    /// <summary>
    /// High level overview of the address validation result and geocode.
    /// </summary>
    public class AddressValidationVerdict
    {
        /// <summary>
        /// The address is considered complete if there are no unresolved tokens,
        /// no unexpected or missing address components.
        /// </summary>
        [JsonProperty("addressComplete")]
        public bool AddressComplete { get; set; }

        /// <summary>
        /// At least one address component was inferred (added) that wasn't in the input.
        /// </summary>
        /// <remarks>
        /// See <see cref="AddressComponent">Address Components</see> for details.
        /// </remarks>
        [JsonProperty("hasInferredComponents")]
        public bool HasInferredComponents { get; set; }

        /// <summary>
        /// At least one address component was replaced.
        /// </summary>
        /// <remarks>
        /// See <see cref="AddressComponent">Address Components</see> for details.
        /// </remarks>
        [JsonProperty("hasReplacedComponents")]
        public bool HasReplacedComponents { get; set; }

        /// <summary>
        /// At least one address component cannot be categorized or validated.
        /// </summary>
        /// <remarks>
        /// See <see cref="AddressComponent">Address Components</see> for details.
        /// </remarks>
        [JsonProperty("hasUnconfirmedComponents")]
        public bool HasUnconfirmedComponents { get; set; }

        /// <summary>
        /// Information about the granularity of the geocode.
        /// </summary>
        [JsonProperty("geocodeGranularity")]
        public AddressValidationGranularity GeocodeGranularity { get; set; }

        /// <summary>
        /// The granularity of the input address.
        /// </summary>
        /// <remarks>
        /// This is the result of parsing the input address and does not give any validation signals.
        /// </remarks>
        [JsonProperty("inputGranularity")]
        public AddressValidationGranularity InputGranularity { get; set; }

        /// <summary>
        /// The granularity level that the API can fully validate the address to.
        /// </summary>
        [JsonProperty("validationGranularity")]
        public AddressValidationGranularity ValidationGranularity { get; set; }
    }
}
