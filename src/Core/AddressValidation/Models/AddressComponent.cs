using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.AddressValidation
{
    /// <summary>
    /// Represents an address component, such as a street, city, or state.
    /// </summary>
    public class AddressComponent
    {
        /// <summary>
        /// The name for this component.
        /// </summary>
        [JsonProperty("componentName")]
        public AddressComponentName ComponentName { get; set; }

        /// <summary>
        /// The type of the address component.
        /// </summary>
        [JsonProperty("componentType")]
        public AddressComponentType ComponentType { get; set; }

        /// <summary>
        /// Indicates the level of certainty that the component is correct.
        /// </summary>
        [JsonProperty("confirmationLevel")]
        public AddressConfirmationLevel ConfirmationLevel { get; set; }

        /// <summary>
        /// Indicates that the component was not part of the input, but we inferred it for
        /// the address location and believe it should be provided for a complete address.
        /// </summary>
        [JsonProperty("inferred")]
        public bool Inferred { get; set; }

        /// <summary>
        /// Indicates the spelling of the component name was corrected in a minor way.
        /// </summary>
        /// <remarks>
        /// For example by switching two characters that appeared in the wrong order.
        /// This indicates a cosmetic change.
        /// </remarks>
        [JsonProperty("spellCorrected")]
        public bool SpellCorrected { get; set; }

        /// <summary>
        /// Indicates the name of the component was replaced with a completely different one.
        /// </summary>
        /// <remarks>
        /// For example a wrong postal code being replaced with one that is correct for the address.
        /// This is not a cosmetic change, the input component has been changed to a different one.
        /// </remarks>
        [JsonProperty("replaced")]
        public bool Replaced { get; set; }

        /// <summary>
        /// Indicates an address component that is not expected to be present in a postal address for
        /// the given region. We have retained it only because it was part of the input.
        /// </summary>
        [JsonProperty("unexpected")]
        public bool Unexpected { get; set; }
    }
}
