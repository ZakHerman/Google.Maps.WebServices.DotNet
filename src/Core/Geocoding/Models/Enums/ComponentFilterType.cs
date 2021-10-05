using System.Runtime.Serialization;
using Google.Maps.WebServices.Common;

namespace Google.Maps.WebServices.Geocoding
{
    /// <summary>
    /// A component filter for a geocode request.
    /// </summary>
    /// <remarks>
    /// <para>
    /// In a geocoding response, the Google Maps Geocoding Web Service can return address results
    /// restricted to a specific area.
    /// </para>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/geocoding/overview#component-filtering">Component
    /// filtering</see> for more detail.
    /// </remarks>
    public enum ComponentFilterType
    {
        /// <summary>
        /// Matches a country name or a two letter <see
        /// href="https://en.wikipedia.org/wiki/ISO_3166-1">ISO 3166-1</see> country code.
        /// </summary>
        /// <remarks>
        /// The API follows the ISO standard for defining countries, and the filtering works best
        /// when using the corresponding ISO code of the country.
        /// </remarks>
        [EnumMember(Value = "country")]
        Country,

        /// <summary>
        /// Matches all the <c>administrative_area</c> levels.
        /// </summary>
        /// <remarks>May be used to influence results, but will not be enforced.</remarks>
        [EnumMember(Value = "administrative_area")]
        AdministrativeArea,

        /// <summary>
        /// Matches <see cref="AddressComponentType.PostalCode" /> and <see
        /// cref="AddressComponentType.PostalCodePrefix" />.
        /// </summary>
        [EnumMember(Value = "postal_code")]
        PostalCode,

        /// <summary>
        /// Matches against <see cref="AddressComponentType.Locality" /> and <see
        /// cref="AddressComponentType.SubLocality" /> types.
        /// </summary>
        /// <remarks>May be used to influence results, but will not be enforced.</remarks>
        [EnumMember(Value = "locality")]
        Locality,

        /// <summary>
        /// Matches the long or short name of a route.
        /// </summary>
        /// <remarks>May be used to influence results, but will not be enforced.</remarks>
        [EnumMember(Value = "route")]
        Route
    }
}
