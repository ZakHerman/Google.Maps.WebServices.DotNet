using System.Collections.Generic;
using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.AddressValidation;

/// <summary>
/// Contains information about the place the input was geocoded to.
/// </summary>
public class AddressValidationGeocode
{
    /// <summary>
    /// The bounds of the geocoded place.
    /// </summary>
    [JsonProperty("bounds")]
    public Viewport Bounds { get; set; }

    /// <summary>
    /// The size of the geocoded place, in meters.
    /// </summary>
    /// <remarks>
    /// This is another measure of the coarseness of the geocoded location,
    /// but in physical size rather than in semantic meaning.
    /// </remarks>
    [JsonProperty("featureSizeMeters")]
    public double FeatureSizeMeters { get; set; }

    /// <summary>
    /// The geocoded location of the input.
    /// </summary>
    [JsonProperty("location")]
    public LatLngLiteral Location { get; set; }

    /// <summary>
    /// The PlaceID of the place this input geocodes to.
    /// </summary>
    [JsonProperty("placeId")]
    public string PlaceId { get; set; }

    /// <summary>
    /// The type(s) of place that the input geocoded to.
    /// </summary>
    [JsonProperty("placeTypes")]
    public List<AddressType> PlaceTypes { get; } = new();

    /// <summary>
    /// The plus code corresponding to the <see cref="Location" />.
    /// </summary>
    [JsonProperty("plusCode")]
    public PlusCode PlusCode { get; set; }
}
