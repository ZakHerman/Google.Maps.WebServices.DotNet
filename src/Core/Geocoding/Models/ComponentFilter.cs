using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Extensions;

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
    public class ComponentFilter : IUrlValue
    {
        /// <summary>
        /// Constructs an instance of the <see cref="ComponentFilter" /> class.
        /// </summary>
        /// <param name="component">The component to filter.</param>
        /// <param name="value">The value of the filter.</param>
        public ComponentFilter(ComponentFilterType component, string value)
        {
            Component = component;
            Value = value;
        }

        /// <summary>
        /// </summary>
        public ComponentFilterType Component { get; }

        /// <summary>
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Matches long or short name of a route.
        /// </summary>
        /// <param name="route">The name of the route to filter by.</param>
        /// <returns>A <see cref="ComponentFilter"/>.</returns>
        public static ComponentFilter SetRoute(string route)
        {
            return new ComponentFilter(ComponentFilterType.Route, route);
        }

        /// <summary>
        /// Matches against both locality and sublocality types.
        /// </summary>
        /// <param name="locality">The locality to filter by.</param>
        /// <returns>A <see cref="ComponentFilter"/>.</returns>
        public static ComponentFilter SetLocality(string locality)
        {
            return new ComponentFilter(ComponentFilterType.Locality, locality);
        }

        /// <summary>
        /// Matches all the administrative area levels.
        /// </summary>
        /// <param name="administrativeArea">The administrative area to filter by.</param>
        /// <returns>A <see cref="ComponentFilter"/>.</returns>
        public static ComponentFilter SetAdministrativeArea(string administrativeArea)
        {
            return new ComponentFilter(ComponentFilterType.AdministrativeArea, administrativeArea);
        }

        /// <summary>
        /// Matches postal code or postal code prefix.
        /// </summary>
        /// <param name="postalCode">The postal code to filter by.</param>
        /// <returns>A <see cref="ComponentFilter"/>.</returns>
        public static ComponentFilter SetPostalCode(string postalCode)
        {
            return new ComponentFilter(ComponentFilterType.PostalCode, postalCode);
        }

        /// <summary>
        /// Matches a country name or a two letter ISO 3166-1 country code.
        /// </summary>
        /// <param name="country">The country to filter by.</param>
        /// <returns>A <see cref="ComponentFilter"/>.</returns>
        public static ComponentFilter SetCountry(string country)
        {
            return new ComponentFilter(ComponentFilterType.Country, country);
        }

        /// <inheritdoc />
        public override string ToString() => ToUriValue();

        /// <inheritdoc />
        public string ToUriValue()
        {
            return string.Join(":", Component.ToUriValue(), Value);
        }
    }
}
