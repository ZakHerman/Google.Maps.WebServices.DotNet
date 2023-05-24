using Newtonsoft.Json;

namespace Google.Maps.WebServices.AddressValidation;

/// <summary>
/// A wrapper for the name of the component.
/// </summary>
public class AddressComponentName
{
    /// <summary>
    /// The name text.
    /// </summary>
    /// <remarks>
    /// For example, "5th Avenue" for a street name or "1253" for a street number.
    /// </remarks>
    [JsonProperty("languageCode")]
    public string LanguageCode { get; set; }

    /// <summary>
    /// The BCP-47 language code.
    /// </summary>
    /// <remarks>
    /// This will not be present if the component name is not associated with a language, such as a street number.
    /// </remarks>
    [JsonProperty("text")]
    public string Text { get; set; }
}