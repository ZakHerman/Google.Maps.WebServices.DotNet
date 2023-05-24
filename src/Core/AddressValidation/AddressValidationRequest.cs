using Newtonsoft.Json;

namespace Google.Maps.WebServices.AddressValidation;

/// <summary>
/// The request body for validation an address.
/// </summary>
public class AddressValidationRequest
{
    /// <summary>
    /// Constructs an instance of the <see cref="AddressValidationRequest" /> class.
    /// </summary>
    public AddressValidationRequest()
    { }

    /// <summary>
    /// Constructs an instance of the <see cref="AddressValidationRequest" /> class.
    /// </summary>
    /// <param name="address">The address being validated.</param>
    /// <param name="previousResponseId">The previous response ID.</param>
    /// <param name="enableUspsCass">Enable USPS CASS.</param>
    public AddressValidationRequest(PostalAddress address, string previousResponseId, bool enableUspsCass)
    {
        Address = address;
        PreviousResponseId = previousResponseId;
        EnableUspsCass = enableUspsCass;
    }

    /// <summary>
    /// The address being validated.
    /// </summary>
    [JsonProperty("address")]
    public PostalAddress Address { get; set; }

    /// <summary>
    /// This field must be empty for the first address validation request.
    /// </summary>
    /// <remarks>
    /// If more requests are necessary to fully validate a single address (for example if
    /// the changes the user makes after the initial validation need to be re-validated),
    /// then each followup request must populate this field with the responseId from the
    /// very first response in the validation sequence.
    /// </remarks>
    [JsonProperty("previousResponseId")]
    public string PreviousResponseId { get; set; }

    /// <summary>
    /// Enables USPS CASS compatible mode.
    /// </summary>
    [JsonProperty("enableUspsCass")]
    public bool EnableUspsCass { get; set; }
}
