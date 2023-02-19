using Newtonsoft.Json;

namespace Google.Maps.WebServices.AddressValidation
{
    /// <summary>
    /// The result of validating an address.
    /// </summary>
    public class AddressValidationResult
    {
        /// <summary>
        /// Information about the address itself as opposed to the geocode.
        /// </summary>
        [JsonProperty("address")]
        public Address Address { get; set; }

        /// <summary>
        /// Information about the location and place that the address geocoded to.
        /// </summary>
        [JsonProperty("geocode")]
        public AddressValidationGeocode Geocode { get; set; }

        /// <summary>
        /// Other information relevant to deliverability.
        /// </summary>
        /// <remarks>
        /// <see cref="MetaData" /> is not guaranteed to be fully populated for every address
        /// sent to the Address Validation API.
        /// </remarks>
        [JsonProperty("metadata")]
        public AddressValidationMetaData MetaData { get; set; }

        /// <summary>
        /// Overall verdict flags.
        /// </summary>
        [JsonProperty("verdict")]
        public AddressValidationVerdict Verdict { get; set; }
    }
}
