using System.Collections.Generic;
using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.AddressValidation;

/// <summary>
/// Represents a postal address.
/// </summary>
public class PostalAddress
{
    /// <summary>
    /// Highest administrative subdivision which is used for postal addresses of a country or region.
    /// </summary>
    /// <remarks>
    /// For example, this can be a state, a province, an oblast, or a prefecture.
    /// </remarks>
    [JsonProperty("administrativeArea")]
    public string AdministrativeArea { get; set; }

    /// <summary>
    /// Unstructured address lines describing the lower levels of an address.
    /// </summary>
    [JsonProperty("addressLines")]
    public List<string> AddressLines { get; set; } = new();

    /// <summary>
    /// The language code in the input address is reserved for future uses and is ignored today.
    /// </summary>
    /// <remarks>
    /// The API returns the address in the appropriate language for where the address is located.
    /// </remarks>
    [JsonProperty("languageCode")]
    public string LanguageCode { get; set; }

    /// <summary>
    /// Generally refers to the city/town portion of the address.
    /// </summary>
    /// <remarks>
    /// In regions of the world where localities are not well defined or do not fit into this structure well,
    /// leave locality empty and use <see cref="AddressLines" />.
    /// </remarks>
    [JsonProperty("locality")]
    public string Locality { get; set; }

    /// <summary>
    /// Please avoid setting this field. The Address Validation API does not currently use it.
    /// </summary>
    /// <remarks>
    /// Although at this time the API will not reject requests with this field set,
    /// the information will be discarded and will not be returned in the response.
    /// </remarks>
    [JsonProperty("organization")]
    public string Organization { get; set; }

    /// <summary>
    /// Postal code of the address.
    /// </summary>
    /// <remarks>
    /// Not all countries use or require postal codes to be present, but where they are used,
    /// they may trigger additional validation with other parts of the address
    /// (e.g. state/zip validation in the U.S.A.).
    /// </remarks>
    [JsonProperty("postalCode")]
    public string PostalCode { get; set; }

    /// <summary>
    /// Please avoid setting this field. The Address Validation API does not currently use it.
    /// </summary>
    /// <remarks>
    /// Although at this time the API will not reject requests with this field set,
    /// the information will be discarded and will not be returned in the response.
    /// </remarks>
    [JsonProperty("recipients")]
    public List<string> Recipients { get; set; } = new();

    /// <summary>
    /// CLDR region code of the country/region of the address.
    /// </summary>
    [JsonProperty("regionCode")]
    public string RegionCode { get; set; }

    /// <summary>
    /// The schema revision of the <see cref="PostalAddress" />.
    /// </summary>
    /// <remarks>
    /// Any value other than 0 will cause the API to return an <see cref="ApiResponseStatus.InvalidArgument"/> error.
    /// </remarks>
    [JsonProperty("revision")]
    public int Revision { get; set; }

    /// <summary>
    /// Additional, country-specific, sorting code.
    /// </summary>
    /// <remarks>
    /// This is not used in most regions. Where it is used, the value is either a string like "CEDEX", optionally followed
    /// by a number (e.g. "CEDEX 7"), or just a number alone, representing the "sector code" (Jamaica), "delivery area
    /// indicator" (Malawi) or "post office indicator" (e.g. Côte d'Ivoire).
    /// </remarks>
    [JsonProperty("sortingCode")]
    public string SortingCode { get; set; }

    /// <summary>
    /// Sublocality of the address.
    /// </summary>
    /// <remarks>
    /// For example, this can be neighborhoods, boroughs, districts.
    /// </remarks>
    [JsonProperty("sublocality")]
    public string Sublocality { get; set; }
}
