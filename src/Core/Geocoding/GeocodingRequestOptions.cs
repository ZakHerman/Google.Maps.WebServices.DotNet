using System;
using System.Collections.Generic;
using System.Linq;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Extensions;

namespace Google.Maps.WebServices.Geocoding;

/// <summary>
/// A request builder class for the geocoding web service.
/// </summary>
public class GeocodingRequestOptions : GoogleMapsRequestOptions<GeocodingRequestOptions>
{
    private const string GeocodingUrlPath = "/maps/api/geocode/json";

    /// <summary>
    /// Constructs an instance of the <see cref="GeocodingRequestOptions" /> class.
    /// </summary>
    public GeocodingRequestOptions() : base(GeocodingUrlPath)
    { }

    /// <summary>
    /// Constructs an instance of the <see cref="GeocodingRequestOptions" /> class.
    /// </summary>
    /// <param name="location">The location to reverse geocode.</param>
    internal GeocodingRequestOptions(LatLngLiteral location) : base(GeocodingUrlPath)
    {
        ArgumentNullException.ThrowIfNull(location, nameof(location));

        SetLocation(location);
    }

    /// <summary>
    /// Constructs an instance of the <see cref="GeocodingRequestOptions" /> class.
    /// </summary>
    /// <param name="address">The address to geocode.</param>
    internal GeocodingRequestOptions(string address) : base(GeocodingUrlPath)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Value cannot be null, empty or consist only of white space characters.", nameof(address));

        SetAddress(address);
    }

    /// <summary>
    /// Constructs an instance of the <see cref="GeocodingRequestOptions" /> class.
    /// </summary>
    /// <param name="componentFilters">The component filters.</param>
    internal GeocodingRequestOptions(IEnumerable<ComponentFilter> componentFilters) : base(GeocodingUrlPath)
    {
        SetComponents(componentFilters);
    }

    /// <summary>
    /// Constructs an instance of the <see cref="GeocodingRequestOptions" /> class.
    /// </summary>
    /// <param name="componentFilters">The component filters.</param>
    internal GeocodingRequestOptions(IDictionary<ComponentFilterType, string> componentFilters) : base(GeocodingUrlPath)
    {
        SetComponents(componentFilters);
    }

    /// <summary>
    /// Sets the bounding box of the viewport within which to bias geocode results more prominently.
    /// </summary>
    /// <remarks>
    /// <para>This parameter will only influence, not fully restrict, results from the geocoder.</para>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/geocoding/overview#Viewports">Viewport
    /// Biasing</see> for more detail.
    /// </remarks>
    /// <param name="southWestBound">The south west bound of the bounding box.</param>
    /// <param name="northEastBound">The north east bound of the bounding box.</param>
    /// <returns>Returns this <see cref="GeocodingRequestOptions" /> for call chaining.</returns>
    public GeocodingRequestOptions SetBounds(LatLngLiteral southWestBound, LatLngLiteral northEastBound)
    {
        ArgumentNullException.ThrowIfNull(southWestBound, nameof(southWestBound));
        ArgumentNullException.ThrowIfNull(northEastBound, nameof(northEastBound));

        return SetQueryParameter("bounds", string.Join("|", southWestBound.ToUriValue(), northEastBound.ToUriValue()));
    }

    /// <summary>
    /// Sets the bounding box of the viewport within which to bias geocode results more prominently.
    /// </summary>
    /// <remarks>
    /// <para>This parameter will only influence, not fully restrict, results from the geocoder.</para>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/geocoding/overview#Viewports">Viewport
    /// Biasing</see> for more detail.
    /// </remarks>
    /// <param name="bounds">The bounding box.</param>
    /// <returns>Returns this <see cref="GeocodingRequestOptions" /> for call chaining.</returns>
    public GeocodingRequestOptions SetBounds(Bounds bounds)
    {
        ArgumentNullException.ThrowIfNull(bounds, nameof(bounds));

        return SetBounds(bounds.SouthWest, bounds.NorthEast);
    }

    /// <summary>
    /// Sets the component filters. Each component filter consists of a <c>component:value</c>
    /// pair and will fully restrict the results from the geocoder.
    /// </summary>
    /// <remarks>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/geocoding/overview#component-filtering">Component
    /// Filtering</see> for more detail.
    /// </remarks>
    /// <param name="componentFilters">Component filters to apply to the request.</param>
    /// <returns>Returns this <see cref="GeocodingRequestOptions" /> for call chaining.</returns>
    public GeocodingRequestOptions SetComponents(IEnumerable<ComponentFilter> componentFilters)
    {
        ArgumentNullException.ThrowIfNull(componentFilters, nameof(componentFilters));

        componentFilters = componentFilters.ToICollection();

        if (componentFilters.Contains(null))
            throw new ArgumentException("Collection cannot contain null values.", nameof(componentFilters));

        return SetQueryParameter("components", string.Join("|", componentFilters));
    }

    /// <inheritdoc cref="SetComponents(IEnumerable{ComponentFilter})" />
    public GeocodingRequestOptions SetComponents(params ComponentFilter[] componentFilters) => SetComponents(componentFilters.ToList());

    /// <inheritdoc cref="SetComponents(IEnumerable{ComponentFilter})" />
    public GeocodingRequestOptions SetComponents(IDictionary<ComponentFilterType, string> componentFilters)
    {
        ArgumentNullException.ThrowIfNull(componentFilters, nameof(componentFilters));

        if (componentFilters.Values.Contains(null))
            throw new ArgumentException("Value cannot contain null values.", nameof(componentFilters));

        return SetQueryParameter("components", string.Join("|", componentFilters.Select(kv => $"{kv.Key.ToUriValue()}:{kv.Value}")));
    }

    /// <summary>
    /// Sets the location type. Specifying a type will restrict the results to this type.
    /// </summary>
    /// <remarks>
    /// If multiple types are specified, the API will return all addresses that match any of the types.
    /// </remarks>
    /// <param name="locationTypes">The location types to restrict to.</param>
    /// <returns>Returns this <see cref="GeocodingRequestOptions" /> for call chaining.</returns>
    public GeocodingRequestOptions SetLocationType(IEnumerable<LocationType> locationTypes)
    {
        return SetQueryParameter("location_type", locationTypes.JoinUriValues());
    }

    /// <inheritdoc cref="SetLocationType(IEnumerable{LocationType})" />
    public GeocodingRequestOptions SetLocationType(params LocationType[] locationTypes) =>
        SetLocationType(locationTypes.ToList());

    /// <summary>
    /// Sets the region code, specified as a ccTLD ("top-level domain") two-character value.
    /// </summary>
    /// <remarks>
    /// <para>This parameter will only influence, not fully restrict, results from the geocoder.</para>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/geocoding/overview#RegionCodes">Region
    /// Biasing</see> for more detail.
    /// </remarks>
    /// <param name="region">The region code to influence results.</param>
    /// <returns>Returns this <see cref="GeocodingRequestOptions" /> for call chaining.</returns>
    public GeocodingRequestOptions SetRegion(string region)
    {
        return SetQueryParameter("region", region);
    }

    /// <summary>
    /// Sets the result type. Specifying a type will restrict the results to this type.
    /// </summary>
    /// <remarks>
    /// If multiple types are specified, the API will return all addresses that match any of the types.
    /// </remarks>
    /// <param name="resultTypes">The result types to restrict to.</param>
    /// <returns>Returns this <see cref="GeocodingRequestOptions" /> for call chaining.</returns>
    public GeocodingRequestOptions SetResultType(IEnumerable<AddressType> resultTypes)
    {
        return SetQueryParameter("result_type", resultTypes.JoinUriValues());
    }

    /// <inheritdoc cref="SetResultType(IEnumerable{AddressType})" />
    public GeocodingRequestOptions SetResultType(params AddressType[] resultTypes) =>
        SetResultType(resultTypes.ToList());

    /// <summary>
    /// Creates a forward geocode for <paramref name="address" />.
    /// </summary>
    /// <param name="address">The address to geocode.</param>
    /// <returns>Returns this <see cref="GeocodingRequestOptions" /> for call chaining.</returns>
    internal GeocodingRequestOptions SetAddress(string address)
    {
        return SetQueryParameter("address", address);
    }

    /// <summary>
    /// Creates a reverse geocode for <paramref name="latLng" />.
    /// </summary>
    /// <param name="latLng">The location to reverse geocode.</param>
    /// <returns>Returns this <see cref="GeocodingRequestOptions" /> for call chaining.</returns>
    internal GeocodingRequestOptions SetLocation(LatLngLiteral latLng)
    {
        return SetQueryParameter("latlng", latLng.ToUriValue());
    }

    /// <summary>
    /// Creates a forward geocode for <paramref name="placeId" />.
    /// </summary>
    /// <param name="placeId">The place ID to geocode.</param>
    /// <returns>Returns this <see cref="GeocodingRequestOptions" /> for call chaining.</returns>
    internal GeocodingRequestOptions SetPlace(string placeId)
    {
        return SetQueryParameter("place_id", placeId);
    }

    /// <inheritdoc />
    internal override void ValidateRequest()
    {
        if (!ContainsQueryParameter("address") && !ContainsQueryParameter("place_id") && !ContainsQueryParameter("components") && !ContainsQueryParameter("latlng"))
            throw new InvalidOperationException("Request must contain at least one of 'address', 'latlng', 'place_id' and 'components'.");

        base.ValidateRequest();
    }
}
