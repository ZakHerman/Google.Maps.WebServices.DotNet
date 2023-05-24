using System;
using System.Collections.Generic;
using System.Linq;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Extensions;

namespace Google.Maps.WebServices.DistanceMatrix;

/// <summary>
/// A request builder class for the distance matrix web service.
/// </summary>
public class DistanceMatrixRequestOptions : GoogleMapsRequestOptions<DistanceMatrixRequestOptions>
{
    private const string DistanceMatrixUrlPath = "/maps/api/distancematrix/json";

    /// <summary>
    /// Constructs an instance of the <see cref="DistanceMatrixRequestOptions" /> class.
    /// </summary>
    public DistanceMatrixRequestOptions() : base(DistanceMatrixUrlPath)
    { }

    /// <summary>
    /// Constructs an instance of the <see cref="DistanceMatrixRequestOptions" /> class.
    /// </summary>
    /// <param name="origins">The locations used as origin points.</param>
    /// <param name="destinations">The locations used as destination points.</param>
    internal DistanceMatrixRequestOptions(List<string> origins, List<string> destinations) : base(DistanceMatrixUrlPath)
    {
        if (origins is null || !origins.Any())
            throw new ArgumentException("Value cannot be null or empty", nameof(origins));

        if (destinations is null || !destinations.Any())
            throw new ArgumentException("Value cannot be null or empty", nameof(destinations));

        SetOrigins(origins);
        SetDestinations(destinations);
    }

    /// <inheritdoc cref="SetArrivalTime(long)" />
    public DistanceMatrixRequestOptions SetArrivalTime(DateTime time) =>
        SetArrivalTime(((DateTimeOffset)time).ToUnixTimeSeconds());

    /// <summary>
    /// Set the desired time of arrival for transit requests, in seconds since midnight, January
    /// 1, 1970 UTC.
    /// </summary>
    /// <param name="time">The desired arrival time to calculate directions for in UTC.</param>
    /// <returns>Returns this <see cref="DistanceMatrixRequestOptions" /> for call chaining.</returns>
    public DistanceMatrixRequestOptions SetArrivalTime(long time)
    {
        return SetQueryParameter("arrival_time", time.ToString());
    }

    /// <inheritdoc cref="SetDepartureTime(long)" />
    public DistanceMatrixRequestOptions SetDepartureTime(DateTime time) =>
        SetDepartureTime(((DateTimeOffset)time).ToUnixTimeSeconds());

    /// <summary>
    /// Set the departure time for a <see cref="TravelMode.Transit" /> or <see
    /// cref="TravelMode.Driving" /> distance matrix request.
    /// </summary>
    /// <remarks>
    /// If both departure time and traffic model are not provided, then "now" is assumed. If
    /// traffic model is supplied, then departure time must be specified.
    /// <para>Duration in traffic will only be returned if the departure time is specified.</para>
    /// </remarks>
    /// <param name="time">The desired departure time in UTC to use for calculations.</param>
    /// <returns>Returns this <see cref="DistanceMatrixRequestOptions" /> for call chaining.</returns>
    public DistanceMatrixRequestOptions SetDepartureTime(long time)
    {
        return SetQueryParameter("departure_time", time.ToString());
    }

    /// <summary>
    /// Set the departure time for a <see cref="TravelMode.Transit" /> or <see
    /// cref="TravelMode.Driving" /> distance matrix request as the current time.
    /// </summary>
    /// <remarks>
    /// If traffic model is supplied, then departure time must be specified.
    /// <para>Duration in traffic will only be returned if the departure time is specified.</para>
    /// </remarks>
    /// <returns>Returns this <see cref="DistanceMatrixRequestOptions" /> for call chaining.</returns>
    public DistanceMatrixRequestOptions SetDepartureTimeNow()
    {
        return SetQueryParameter("departure_time", "now");
    }

    /// <summary>
    /// Set the region to influence results to use the given <paramref name="region" />.
    /// </summary>
    /// <param name="region">
    /// The region code, specified as a ccTLD ("top-level domain") two-character value.
    /// </param>
    /// <returns>Returns this <see cref="DistanceMatrixRequestOptions" /> for call chaining.</returns>
    public DistanceMatrixRequestOptions SetPreferredRegion(string region)
    {
        return SetQueryParameter("region", region);
    }

    /// <summary>
    /// Specifies the unit system to use when expressing distance as text.
    /// </summary>
    /// <remarks>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/distance-matrix/overview#unit_systems">Unit
    /// Systems</see> for more detail.
    /// </remarks>
    /// <param name="units">The preferred units for displaying distances.</param>
    /// <returns>Returns this <see cref="DistanceMatrixRequestOptions" /> for call chaining.</returns>
    public DistanceMatrixRequestOptions SetPreferredUnitSystem(Unit units)
    {
        return SetQueryParameter("units", units.ToUriValue());
    }

    /// <summary>
    /// Indicates that the calculated route(s) should avoid the indicated feature.
    /// </summary>
    /// <remarks>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/distance-matrix/overview#Restrictions">Restrictions</see>
    /// for more detail.
    /// </remarks>
    /// <param name="restriction">The <see cref="RouteRestriction" /> to avoid.</param>
    /// <returns>Returns this <see cref="DistanceMatrixRequestOptions" /> for call chaining.</returns>
    public DistanceMatrixRequestOptions SetRouteRestrictions(RouteRestriction restriction)
    {
        return SetQueryParameter("avoid", restriction.ToUriValue());
    }

    /// <summary>
    /// Specifies the assumptions to use when calculating time in traffic.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This setting affects the value returned in the 'duration_in_traffic' field in the
    /// response, which contains the predicted time in traffic based on historical averages.
    /// </para>
    /// Once set, you must specify a departure time.
    /// </remarks>
    /// <param name="trafficModel">The traffic model for estimating driving time.</param>
    /// <returns>Returns this <see cref="DistanceMatrixRequestOptions" /> for call chaining.</returns>
    public DistanceMatrixRequestOptions SetTrafficModel(TrafficModel trafficModel)
    {
        return SetQueryParameter("traffic_model", trafficModel.ToUriValue());
    }

    /// <summary>
    /// Specifies one or more preferred modes of transit.
    /// </summary>
    /// <remarks>This parameter may only be specified for requests where the mode is transit.</remarks>
    /// <param name="transitModes">The preferred transit modes.</param>
    /// <returns>Returns this <see cref="DistanceMatrixRequestOptions" /> for call chaining.</returns>
    public DistanceMatrixRequestOptions SetTransitModes(IEnumerable<TransitMode> transitModes)
    {
        return SetQueryParameter("transit_mode", string.Join("|", transitModes));
    }

    /// <summary>
    /// Specifies preferences for transit requests.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Using this parameter, you can bias the options returned, rather than accepting the
    /// default best route chosen by the Web Service.
    /// </para>
    /// <para>
    /// This parameter may only be specified for requests where the mode is <see
    /// cref="TravelMode.Transit" />.
    /// </para>
    /// </remarks>
    /// <param name="transitRoutingPreference">The transit routing preferences for this request.</param>
    /// <returns>Returns this <see cref="DistanceMatrixRequestOptions" /> for call chaining.</returns>
    public DistanceMatrixRequestOptions SetTransitRoutingPreference(TransitRoutingPreference transitRoutingPreference)
    {
        return SetQueryParameter("transit_routing_preference", transitRoutingPreference.ToUriValue());
    }

    /// <summary>
    /// Specifies the mode of transport to use when calculating directions.
    /// </summary>
    /// <remarks>
    /// The mode defaults to driving if left unspecified. If you set the mode to <see
    /// cref="TravelMode.Transit" /> you must also specify either a 'departure_time' or an 'arrival_time'.
    /// </remarks>
    /// <param name="mode">The travel model to calculate directions for.</param>
    /// <returns>Returns this <see cref="DistanceMatrixRequestOptions" /> for call chaining.</returns>
    public DistanceMatrixRequestOptions SetTravelMode(TravelMode mode)
    {
        return SetQueryParameter("mode", mode.ToUriValue());
    }

    /// <summary>
    /// One or more addresses from which to calculate distance and time.
    /// </summary>
    /// <remarks>
    /// The distance matrix web service will geocode the strings and convert them to
    /// latitude/longitude coordinates to calculate directions.
    /// </remarks>
    /// <param name="destinations">The locations used as destination points.</param>
    /// <returns>Returns this <see cref="DistanceMatrixRequestOptions" /> for call chaining.</returns>
    internal DistanceMatrixRequestOptions SetDestinations(IEnumerable<string> destinations)
    {
        return SetQueryParameter("destinations", string.Join("|", destinations));
    }

    /// <summary>
    /// One or more addresses from which to calculate distance and time.
    /// </summary>
    /// <remarks>
    /// The distance matrix web service will geocode the strings and convert them to
    /// latitude/longitude coordinates to calculate directions.
    /// </remarks>
    /// <param name="origins">The locations used as origin points.</param>
    /// <returns>Returns this <see cref="DistanceMatrixRequestOptions" /> for call chaining.</returns>
    internal DistanceMatrixRequestOptions SetOrigins(IEnumerable<string> origins)
    {
        return SetQueryParameter("origins", string.Join("|", origins));
    }

    /// <inheritdoc />
    internal override void ValidateRequest()
    {
        if (!ContainsQueryParameter("origins"))
            throw new InvalidOperationException("Invalid request. Missing the 'origins' parameter.");

        if (!ContainsQueryParameter("destinations"))
            throw new InvalidOperationException("Invalid request. Missing the 'destinations' parameter.");

        if (ContainsQueryParameter("arrival_time") && ContainsQueryParameter("departure_time"))
            throw new InvalidOperationException("Transit request must not contain both an 'arrival_time' and a 'departure_time'");

        base.ValidateRequest();
    }
}