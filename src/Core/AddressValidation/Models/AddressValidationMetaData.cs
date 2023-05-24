using Newtonsoft.Json;

namespace Google.Maps.WebServices.AddressValidation;

/// <summary>
/// The metadata for the address.
/// </summary>
public class AddressValidationMetaData
{
    /// <summary>
    /// Indicates that this is the address of a business. If unset,
    /// indicates that the value is unknown.
    /// </summary>
    [JsonProperty("business")]
    public bool Business { get; set; }

    /// <summary>
    /// Indicates that the address of a PO box. If unset,
    /// indicates that the value is unknown.
    /// </summary>
    [JsonProperty("poBox")]
    public bool PoBox { get; set; }

    /// <summary>
    /// Indicates that this is the address of a residence. If unset,
    /// indicates that the value is unknown.
    /// </summary>
    [JsonProperty("residential")]
    public bool Residential { get; set; }
}