using System;
using System.Collections.Generic;
using System.Linq;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Extensions;

namespace Google.Maps.WebServices.Directions
{
    /// <summary>
    /// A request builder class for the directions web service.
    /// </summary>
    public class DirectionsRequestOptions : GoogleMapsRequestOptions<DirectionsRequestOptions>
    {
        private const string DirectionsUrlPath = "/maps/api/directions/json";
        private bool _optimizeWaypoints;

        /// <summary>
        /// The destination of the the route.
        /// </summary>
        public string Destination { get; private set; }

        /// <summary>
        /// The origin of the route.
        /// </summary>
        public string Origin { get; private set; }

        /// <summary>
        /// The waypoints of the route.
        /// </summary>
        public ICollection<Waypoint> Waypoints { get; set; } = new List<Waypoint>();

        /// <summary>
        /// Constructs an instance of the <see cref="DirectionsRequestOptions" /> class.
        /// </summary>
        public DirectionsRequestOptions() : base(DirectionsUrlPath)
        { }

        /// <summary>
        /// Constructs an instance of the <see cref="DirectionsRequestOptions" /> class.
        /// </summary>
        /// <param name="uri">The URI.</param>
        public DirectionsRequestOptions(Uri uri) : base(uri)
        { }

        /// <summary>
        /// Constructs an instance of the <see cref="DirectionsRequestOptions" /> class.
        /// </summary>
        /// <param name="origin">
        /// The place ID, address, textual latitude/longitude value, <see cref="PlusCode.GlobalCode"
        /// /> or <see cref="PlusCode.CompoundCode" /> value to use as a starting location to
        /// calculate directions.
        /// </param>
        /// <param name="destination">
        /// The place ID, address, textual latitude/longitude value, <see cref="PlusCode.GlobalCode"
        /// /> or <see cref="PlusCode.CompoundCode" /> value to use as an ending location to
        /// calculate directions.
        /// </param>
        internal DirectionsRequestOptions(string origin, string destination) : base(DirectionsUrlPath)
        {
            if (string.IsNullOrWhiteSpace(origin))
                throw new ArgumentException("Value cannot be null, empty or white space.", nameof(origin));

            if (string.IsNullOrWhiteSpace(destination))
                throw new ArgumentException("Value cannot be null, empty or white space.", nameof(destination));

            SetOrigin(origin);
            SetDestination(destination);
        }

        /// <summary>
        /// If set to true, specifies that the Directions service may provide more than one route
        /// alternative in the response.
        /// </summary>
        /// <remarks>Providing route alternatives may increase the response time from the server.</remarks>
        /// <param name="alternateRoutes">Indicates whether to return alternate routes.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions AllowRouteAlternatives(bool alternateRoutes = true)
        {
            return SetQueryParameter("alternatives", alternateRoutes.ToString());
        }

        /// <summary>
        /// Allow the Directions service to optimize the provided route by rearranging the waypoints
        /// in a more efficient order.
        /// </summary>
        /// <remarks>
        /// See <see
        /// href="https://developers.google.com/maps/documentation/directions/get-directions#OptimizeWaypoints">Optimize
        /// Waypoints</see> for more detail.
        /// </remarks>
        /// <param name="optimize">Indicates whether to optimize waypoints.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions OptimizeWaypoints(bool optimize = true)
        {
            _optimizeWaypoints = optimize;

            return Waypoints.Any()
                ? SetWaypoints(Waypoints)
                : this;
        }

        /// <inheritdoc cref="SetArrivalTime(long)" />
        public DirectionsRequestOptions SetArrivalTime(DateTime arrivalTime)
        {
            if (arrivalTime.Kind == DateTimeKind.Unspecified)
                throw new ArgumentException("Value has to be specified with a date time kind of local or UTC.", nameof(arrivalTime));

            return SetArrivalTime((DateTimeOffset)arrivalTime);
        }

        /// <inheritdoc cref="SetArrivalTime(long)" />
        public DirectionsRequestOptions SetArrivalTime(DateTimeOffset arrivalTime)
        {
            return SetArrivalTime(arrivalTime.ToUnixTimeSeconds());
        }

        /// <summary>
        /// Set the arrival time for a <see cref="TravelMode.Transit" /> directions request.
        /// </summary>
        /// <param name="arrivalTime">The arrival time to calculate directions for in UTC.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetArrivalTime(long arrivalTime)
        {
            return SetQueryParameter("arrival_time", arrivalTime.ToString());
        }

        /// <inheritdoc cref="SetDepartureTime(long)" />
        public DirectionsRequestOptions SetDepartureTime(DateTime departureTime)
        {
            if (departureTime.Kind == DateTimeKind.Unspecified)
                throw new ArgumentException("Value has to be specified as local or UTC time.", nameof(departureTime));

            return SetDepartureTime((DateTimeOffset)departureTime);
        }

        /// <inheritdoc cref="SetDepartureTime(long)" />
        public DirectionsRequestOptions SetDepartureTime(DateTimeOffset departureTime)
        {
            return SetDepartureTime(departureTime.ToUnixTimeSeconds());
        }

        /// <summary>
        /// Set the departure time for a <see cref="TravelMode.Transit" /> or <see
        /// cref="TravelMode.Driving" /> directions request.
        /// </summary>
        /// <remarks>
        /// If both departure time and traffic model are not provided, then "now" is assumed. If
        /// traffic model is supplied, then departure time must be specified.
        /// <para>Duration in traffic will only be returned if the departure time is specified.</para>
        /// </remarks>
        /// <param name="departureTime">The departure time to calculate directions for in UTC.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetDepartureTime(long departureTime)
        {
            return SetQueryParameter("departure_time", departureTime.ToString());
        }

        /// <summary>
        /// Set the departure time for a <see cref="TravelMode.Transit" /> or <see
        /// cref="TravelMode.Driving" /> directions request as the current time.
        /// </summary>
        /// <remarks>
        /// If traffic model is supplied, then departure time must be specified.
        /// <para>Duration in traffic will only be returned if the departure time is specified.</para>
        /// </remarks>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetDepartureTimeNow()
        {
            return SetQueryParameter("departure_time", "now");
        }

        /// <summary>
        /// The address or textual latitude/longitude value from which you wish to calculate directions.
        /// </summary>
        /// <remarks>
        /// If you pass an address as a location, the Directions service will geocode the location
        /// and convert it to a latitude/longitude coordinate to calculate directions.
        /// </remarks>
        /// <param name="destination">The ending location for the Directions request.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetDestination(string destination)
        {
            Destination = destination;
            return SetQueryParameter("destination", destination);
        }

        /// <summary>
        /// The address or textual latitude/longitude value from which you wish to calculate directions.
        /// </summary>
        /// <remarks>
        /// If you pass an address as a location, the Directions service will geocode the location
        /// and convert it to a latitude/longitude coordinate to calculate directions.
        /// </remarks>
        /// <param name="origin">The starting location for the Directions request.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetOrigin(string origin)
        {
            Origin = origin;
            return SetQueryParameter("origin", origin);
        }

        /// <summary>
        /// Set the region to influence results to use the given <paramref name="region" />.
        /// </summary>
        /// <remarks>
        /// See <see
        /// href="https://developers.google.com/maps/documentation/directions/get-directions#RegionBiasing">Region
        /// Biasing</see> for more detail.
        /// </remarks>
        /// <param name="region">
        /// The region code, specified as a ccTLD ("top-level domain") two-character value.
        /// </param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetPreferredRegion(string region)
        {
            return SetQueryParameter("region", region);
        }

        /// <summary>
        /// Specifies the unit system to use when displaying results.
        /// </summary>
        /// <remarks>
        /// See <see
        /// href="https://developers.google.com/maps/documentation/directions/get-directions#unit-systems">Unit
        /// Systems</see> for more detail.
        /// </remarks>
        /// <param name="units">The preferred units for displaying distances.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetPreferredUnitSystem(Unit units)
        {
            return SetQueryParameter("units", units.ToUriValue());
        }

        /// <summary>
        /// Indicates that the calculated route(s) should avoid the indicated features.
        /// </summary>
        /// <remarks>
        /// See <see
        /// href="https://developers.google.com/maps/documentation/directions/get-directions#Restrictions">Route
        /// Restrictions</see> for more detail.
        /// </remarks>
        /// <param name="restrictions">A collection of <see cref="RouteRestriction" />.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetRouteRestrictions(IEnumerable<RouteRestriction> restrictions)
        {
            return SetQueryParameter("avoid", string.Join("|", restrictions));
        }

        /// <summary>
        /// Specifies the traffic model to use when requesting future driving directions.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This setting affects the value returned in the 'duration_in_traffic' field in the
        /// response, which contains the predicted time in traffic based on historical averages.
        /// </para>
        /// Once set, you must specify a departure time.
        /// </remarks>
        /// <param name="trafficModel">The traffic model for estimating driving time.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetTrafficModel(TrafficModel trafficModel)
        {
            return SetQueryParameter("traffic_model", trafficModel.ToUriValue());
        }

        /// <summary>
        /// Specifies a collection of preferred modes of transit.
        /// </summary>
        /// <remarks>This parameter may only be specified for requests where the mode is transit.</remarks>
        /// <param name="transitModes">The preferred transit modes.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetTransitModes(IEnumerable<TransitMode> transitModes)
        {
            return SetQueryParameter("transit_mode", string.Join("|", transitModes));
        }

        /// <summary>
        /// Specifies preferences for transit requests.
        /// </summary>
        /// <remarks>
        /// Using this parameter, you can bias the options returned, rather than accepting the
        /// default best route chosen by the API.
        /// </remarks>
        /// <param name="transitRoutingPreference">The transit routing preferences for this request.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetTransitRoutingPreference(TransitRoutingPreference transitRoutingPreference)
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
        /// <param name="mode">The starting location for the Directions request.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetTravelMode(TravelMode mode)
        {
            return SetQueryParameter("mode", mode.ToUriValue());
        }

        /// <summary>
        /// Specifies a list of waypoints.
        /// </summary>
        /// <remarks>
        /// <para>Waypoints alter a route by routing it through the specified location(s).
        /// <para>
        /// A waypoint is specified as either a latitude/longitude coordinate or as an address which
        /// will be geocoded.
        /// </para>
        /// </para>
        /// <para>Waypoints are only supported for driving, walking and bicycling directions.</para>
        /// <para>
        /// See <see
        /// href="https://developers.google.com/maps/documentation/directions/get-directions#Waypoints">Route
        /// Waypoints</see> for more detail.
        /// </para>
        /// </remarks>
        /// <param name="waypoints">The waypoints to add to this directions request.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetWaypoints(ICollection<Waypoint> waypoints)
        {
            if (waypoints is null)
                throw new ArgumentNullException(nameof(waypoints));

            if (!waypoints.Any())
                return RemoveQueryParameter("waypoints");

            Waypoints = waypoints;

            string optimizePrefix = _optimizeWaypoints ? "optimize:true|" : string.Empty;

            return SetQueryParameter("waypoints", optimizePrefix + string.Join("|", waypoints));
        }

        /// <summary>
        /// Specifies the list of waypoints as textual addresses.
        /// </summary>
        /// <param name="waypoints">The waypoints to add to this directions request.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetWaypoints(IEnumerable<string> waypoints)
        {
            if (waypoints is null)
                throw new ArgumentNullException(nameof(waypoints));

            var newWaypoints = waypoints.Select(waypoint => new Waypoint(waypoint)).ToList();

            return SetWaypoints(newWaypoints);
        }

        /// <summary>
        /// Specifies the list of waypoints as latitude/longitude locations.
        /// </summary>
        /// <param name="waypoints">The waypoints to add to this directions request.</param>
        /// <returns>Returns this <see cref="DirectionsRequestOptions" /> for call chaining.</returns>
        public DirectionsRequestOptions SetWaypoints(IEnumerable<LatLngLiteral> waypoints)
        {
            if (waypoints is null)
                throw new ArgumentNullException(nameof(waypoints));

            var newWaypoints = waypoints.Select(waypoint => new Waypoint(waypoint.ToUriValue())).ToList();

            return SetWaypoints(newWaypoints);
        }

        /// <inheritdoc />
        internal override void ValidateRequest()
        {
            if (!ContainsQueryParameter("origin"))
                ValidationFailures.Add("origin", "Invalid request. Missing the 'origin' parameter.");

            if (!ContainsQueryParameter("destination"))
                ValidationFailures.Add("destination", "Invalid request. Missing the 'destination' parameter.");

            if (ContainsQueryParameter("arrival_time") && ContainsQueryParameter("departure_time"))
                ValidationFailures.Add("arrival_time", "Transit request must not contain both an 'arrival_time' and a 'departure_time'.");

            if (ContainsQueryParameter("traffic_model") && !ContainsQueryParameter("departure_time"))
                ValidationFailures.Add("traffic_model", "Specifying a traffic model requires that 'departure_time' be provided.");

            base.ValidateRequest();
        }
    }
}
