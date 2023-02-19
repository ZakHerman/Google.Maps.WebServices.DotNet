using System.Collections.Generic;
using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.AddressValidation
{
    /// <summary>
    /// Details of the address parsed from the input.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// The individual address components of the formatted and corrected address,
        /// along with validation information.
        /// </summary>
        [JsonProperty("addressComponents")]
        public List<AddressComponent> AddressComponents { get; } = new List<AddressComponent>();

        /// <summary>
        /// The corrected address, formatted as a single-line address following the address
        /// formatting rules of the region where the address is located.
        /// </summary>
        [JsonProperty("formattedAddress")]
        public string FormattedAddress { get; set; }

        /// <summary>
        /// The types of components that were expected to be present in a correctly formatted
        /// mailing address but were not found in the input AND could not be inferred.
        /// </summary>
        /// <remarks>
        /// Components of this type are not present in <see cref="FormattedAddress" />,
        /// <see cref="PostalAddress" />, or <see cref="AddressComponents" />.
        /// </remarks>
        [JsonProperty("missingComponentTypes")]
        public List<string> MissingComponentTypes { get; } = new List<string>();

        /// <summary>
        /// The validated address represented as a postal address.
        /// </summary>
        [JsonProperty("postalAddress")]
        public PostalAddress PostalAddress { get; set; }

        /// <summary>
        /// The types of the components that are present in the <see cref="AddressComponents"/> but
        /// could not be confirmed to be correct.
        /// </summary>
        /// <remarks>
        /// This field is provided for the sake of convenience: its contents are equivalent to iterating
        /// through the <see cref="AddressComponents" /> to find the types of all the components where
        /// the confirmationLevel is not CONFIRMED or the inferred flag is not set to true.
        /// </remarks>
        [JsonProperty("unconfirmedComponentTypes")]
        public List<AddressComponentType> UnconfirmedComponentTypes { get; } = new List<AddressComponentType>();

        /// <summary>
        /// Any tokens in the input that could not be resolved.
        /// </summary>
        /// <remarks>
        /// This might be an input that was not recognized as a valid part of an address (for example in an
        /// input like "123235253253 Main St, San Francisco, CA, 94105", the unresolved tokens may look like
        /// ["123235253253"] since that does not look like a valid street number.
        /// </remarks>
        [JsonProperty("unresolvedTokens")]
        public List<string> UnresolvedTokens { get; } = new List<string>();
    }
}
