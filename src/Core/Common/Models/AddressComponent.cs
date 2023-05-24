using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Common;

/// <summary>
/// The parts of an address.
/// </summary>
/// <remarks>
/// See <see
/// href="https://developers.google.com/maps/documentation/geocoding/overview#Types">Address
/// Types and Address Component Types</see> for more detail.
/// </remarks>
public class AddressComponent
{
    /// <summary>
    /// Indicates the type of each part of the address.
    /// </summary>
    /// <remarks>Examples include street number or country.</remarks>
    [JsonProperty("types")]
    public List<AddressComponentType> AddressComponentTypes { get; } = new();

    /// <summary>
    /// The full text description or name of the address component as returned by the geocoder.
    /// </summary>
    [JsonProperty("long_name")]
    public string LongName { get; set; }

    /// <summary>
    /// An abbreviated textual name for the address component, if available.
    /// </summary>
    /// <remarks>
    /// For example, an address component for the state of Alaska may have a longName of
    /// "Alaska" and a shortName of "AK" using the 2-letter postal abbreviation.
    /// </remarks>
    [JsonProperty("short_name")]
    public string ShortName { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        var sb = new StringBuilder($"[{nameof(AddressComponent)}:");

        sb.Append($" {nameof(LongName)} = {LongName}");
        sb.Append($", {nameof(ShortName)} = {ShortName}");
        sb.Append($", {nameof(AddressComponentTypes)} = [").AppendJoin(", ", AddressComponentTypes).Append(']');

        return sb.Append(']').ToString();
    }
}
