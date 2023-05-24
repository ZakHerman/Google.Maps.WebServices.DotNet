using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Google.Maps.WebServices.Common;

namespace Google.Maps.WebServices.Geocoding;

/// <summary>
/// <para>
/// Geocoding is the process of converting addresses (like "1600 Amphitheatre Parkway, Mountain
/// View, CA") into geographic coordinates (like latitude 37.423021 and longitude -122.083739),
/// which you can use to place markers or position the map.
/// </para>
/// Reverse geocoding is the process of converting geographic coordinates into a human-readable address.
/// </summary>
/// <remarks>
/// See <see
/// href="https://developers.google.com/maps/documentation/geocoding/overview">Geocoding
/// documentation</see> for more detail.
/// </remarks>
public static class GeocodingService
{
    /// <summary>
    /// Requests the latitude and longitude of the given <paramref name="address" />.
    /// </summary>
    /// <remarks>
    /// The <paramref name="address" /> parameter accepts the following:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// An address in accordance with the format used by the national postal service of the
    /// country concerned.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// A <see cref="PlusCode.GlobalCode" /> as a 4 character area code and 6 character or
    /// longer local code.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// A <see cref="PlusCode.CompoundCode" /> as a 6 character or longer local code with an
    /// explicit location.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <param name="client">
    /// The instance of <see cref="GoogleMapsServiceClient" /> used to send the request.
    /// </param>
    /// <param name="address">The address to geocode.</param>
    /// <param name="options">
    /// A <see cref="GeocodingRequestOptions" /> used to set additional request query parameters.
    /// </param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>
    /// A <see cref="GoogleMapsResponse{T}" /> of the forward geocoding of <paramref
    /// name="address" />.
    /// </returns>
    public static Task<GoogleMapsResponse<IEnumerable<GeocodingResult>>> GeocodeAsync(this GoogleMapsServiceClient client, string address,
        GeocodingRequestOptions options = null, CancellationToken cancellationToken = default)
    {
        options = options?.SetAddress(address) ?? new GeocodingRequestOptions(address);
        return client.GetAsync<GeocodingRequestOptions, GeocodingServiceResponse, IEnumerable<GeocodingResult>>(options, cancellationToken);
    }

    /// <inheritdoc cref="GeocodeAsync(GoogleMapsServiceClient, string, GeocodingRequestOptions, CancellationToken)" />
    public static Task<GoogleMapsResponse<IEnumerable<GeocodingResult>>> GeocodeAsync(this GoogleMapsServiceClient client, PlusCode address,
        GeocodingRequestOptions request = null, CancellationToken cancellationToken = default) =>
        GeocodeAsync(client, address?.GlobalCode ?? address?.CompoundCode, request, cancellationToken);

    /// <summary>
    /// Requests the latitude and longitude of the given <paramref name="componentFilters" />.
    /// </summary>
    /// <remarks>
    /// The components filter is also accepted as an optional parameter if an address is provided.
    /// </remarks>
    /// <param name="client">
    /// The instance of <see cref="GoogleMapsServiceClient" /> used to send the request.
    /// </param>
    /// <param name="componentFilters">The component filters to apply to the geocoder.</param>
    /// <param name="options">
    /// A <see cref="GeocodingRequestOptions" /> used to set additional request query parameters.
    /// </param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>
    /// A <see cref="IEnumerable{GeocodingResult}" /> of the forward geocoding of <paramref
    /// name="componentFilters" />.
    /// </returns>
    public static Task<GoogleMapsResponse<IEnumerable<GeocodingResult>>> GeocodeAsync(this GoogleMapsServiceClient client, IEnumerable<ComponentFilter> componentFilters,
        GeocodingRequestOptions options = null, CancellationToken cancellationToken = default)
    {
        options = options?.SetComponents(componentFilters) ?? new GeocodingRequestOptions(componentFilters);
        return client.GetAsync<GeocodingRequestOptions, GeocodingServiceResponse, IEnumerable<GeocodingResult>>(options, cancellationToken);
    }

    /// <inheritdoc cref="GeocodeAsync(GoogleMapsServiceClient, IEnumerable{ComponentFilter}, GeocodingRequestOptions, CancellationToken)" />
    public static Task<GoogleMapsResponse<IEnumerable<GeocodingResult>>> GeocodeAsync(this GoogleMapsServiceClient client, IDictionary<ComponentFilterType, string> componentFilters,
        GeocodingRequestOptions options = null, CancellationToken cancellationToken = default)
    {
        options = options?.SetComponents(componentFilters) ?? new GeocodingRequestOptions(componentFilters);
        return client.GetAsync<GeocodingRequestOptions, GeocodingServiceResponse, IEnumerable<GeocodingResult>>(options, cancellationToken);
    }

    /// <summary>
    /// Requests the street address of a <paramref name="location" />.
    /// </summary>
    /// <param name="client">
    /// The instance of <see cref="GoogleMapsServiceClient" /> used to send the request.
    /// </param>
    /// <param name="location">The location to reverse geocode.</param>
    /// <param name="options">
    /// A <see cref="GeocodingRequestOptions" /> used to set additional request query parameters.
    /// </param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>
    /// A <see cref="GoogleMapsResponse{T}" /> of the reverse geocoding of <paramref
    /// name="location" />.
    /// </returns>
    public static Task<GoogleMapsResponse<IEnumerable<GeocodingResult>>> ReverseGeocodeAsync(this GoogleMapsServiceClient client, LatLngLiteral location,
        GeocodingRequestOptions options = null, CancellationToken cancellationToken = default)
    {
        options = options?.SetLocation(location) ?? new GeocodingRequestOptions(location);
        return client.GetAsync<GeocodingRequestOptions, GeocodingServiceResponse, IEnumerable<GeocodingResult>>(options, cancellationToken);
    }
}