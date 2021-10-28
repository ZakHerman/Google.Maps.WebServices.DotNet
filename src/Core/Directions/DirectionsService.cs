using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Google.Maps.WebServices.Common;

namespace Google.Maps.WebServices.Directions
{
    /// <summary>
    /// <see cref="DirectionsService" /> is a service that calculates directions between locations.
    /// </summary>
    /// <remarks>
    /// <para>
    /// You can search for directions for several modes of transportation, include transit, driving,
    /// walking, or cycling. Directions may specify origins, destinations, and waypoints, either as
    /// text strings (e.g. "Chicago, IL" or "Darwin, NT, Australia") or as latitude/longitude coordinates.
    /// </para>
    /// <para>The Directions API can return multi-part directions using a series of waypoints.</para>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/directions/get-directions">Directions
    /// documentation</see> for more detail.
    /// </remarks>
    public static class DirectionsService
    {
        private const int MaxWaypointsLimit = 25;

        /// <summary>
        /// Requests the directions between the given <paramref name="origin" /> and <paramref
        /// name="destination" />.
        /// </summary>
        /// <param name="client">
        /// The instance of <see cref="GoogleMapsServiceClient" /> used to send the request.
        /// </param>
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
        /// <param name="options">
        /// A <see cref="DirectionsRequestOptions" /> used to set additional request query parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// A <see cref="GoogleMapsResponse{DirectionsResult}" /> between the given <paramref name="origin" />
        /// and <paramref name="destination" />.
        /// </returns>
        public static Task<GoogleMapsResponse<DirectionsResult>> GetDirectionsAsync(this GoogleMapsServiceClient client, string origin,
            string destination, DirectionsRequestOptions options = null, CancellationToken cancellationToken = default)
        {
            options = options?.SetOrigin(origin).SetDestination(destination) ?? new DirectionsRequestOptions(origin, destination);

            return client.GetAsync<DirectionsRequestOptions, DirectionsServiceResponse, DirectionsResult>(options, cancellationToken);
        }

        /// <inheritdoc cref="GetDirectionsAsync(GoogleMapsServiceClient, string, string, DirectionsRequestOptions, CancellationToken)" path="//*[not(self::param)]" />
        /// <param name="client">
        /// The instance of <see cref="GoogleMapsServiceClient" /> used to send the request.
        /// </param>
        /// <param name="origin">
        /// The <see cref="LatLng" /> value to use as a starting location to calculate directions.
        /// </param>
        /// <param name="destination">
        /// The <see cref="LatLng" /> value to use as an ending location to calculate directions.
        /// </param>
        /// <param name="options">
        /// A <see cref="DirectionsRequestOptions" /> used to set additional request query parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        public static Task<GoogleMapsResponse<DirectionsResult>> GetDirectionsAsync(this GoogleMapsServiceClient client, LatLng origin,
            LatLng destination, DirectionsRequestOptions options = null, CancellationToken cancellationToken = default) =>
            GetDirectionsAsync(client, origin.ToUriValue(), destination.ToUriValue(), options, cancellationToken);

        /// <inheritdoc cref="GetDirectionsAsync(GoogleMapsServiceClient, string, string, DirectionsRequestOptions, CancellationToken)" path="//*[not(self::param)]" />
        /// <param name="client">
        /// The instance of <see cref="GoogleMapsServiceClient" /> used to send the request.
        /// </param>
        /// <param name="origin">
        /// The <see cref="PlusCode" /> value to use as a starting location to calculate directions.
        /// </param>
        /// <param name="destination">
        /// The <see cref="PlusCode" /> value to use as an ending location to calculate directions.
        /// </param>
        /// <param name="options">
        /// A <see cref="DirectionsRequestOptions" /> used to set additional request query parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        public static Task<GoogleMapsResponse<DirectionsResult>> GetDirectionsAsync(this GoogleMapsServiceClient client, PlusCode origin,
            PlusCode destination, DirectionsRequestOptions options = null, CancellationToken cancellationToken = default) =>
            GetDirectionsAsync(client, origin?.GlobalCode ?? origin?.CompoundCode, destination?.GlobalCode ?? origin?.CompoundCode, options, cancellationToken);

        internal static async Task<DirectionsResult> BatchDirectionsAsync(GoogleMapsServiceClient client, DirectionsRequestOptions options,
            CancellationToken cancellationToken = default)
        {
            /*IEnumerable<DirectionsRequestOptions> directionsRequestOptions = SplitDirectionsRequestOptions(options);
            List<Task<DirectionsResult>> tasks = new List<Task<DirectionsResult>>();

            foreach (DirectionsRequestOptions directionsRequestOption in directionsRequestOptions)
            {
                var task = client.GetAsync<DirectionsRequestOptions, DirectionsServiceResponse, DirectionsResult>(directionsRequestOption, cancellationToken);
                tasks.Add(task);
            }

            DirectionsResult[] results = await Task.WhenAll(tasks);

            return results.Skip(1).Aggregate(results[0], DirectionsResult.Merge);*/
            return null;
        }

        internal static IEnumerable<DirectionsRequestOptions> SplitDirectionsRequestOptions(DirectionsRequestOptions options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            if (options.Waypoints.Count <= MaxWaypointsLimit)
                return new List<DirectionsRequestOptions> { options };

            var waypoints = new List<Waypoint>();
            waypoints.Add(new Waypoint(options.Origin));
            waypoints.AddRange(options.Waypoints);
            waypoints.Add(new Waypoint(options.Destination));

            var requestOptions = new List<DirectionsRequestOptions>();

            for (int i = 0; i < waypoints.Count; i += Math.Min(MaxWaypointsLimit + 1, waypoints.Count - i))
            {
                Waypoint requestOrigin = waypoints[i];
                List<Waypoint> requestWaypoints = waypoints.GetRange(i + 1, Math.Min(MaxWaypointsLimit, waypoints.Count - i - 2));
                Waypoint requestDestination = waypoints[i + Math.Min(MaxWaypointsLimit + 1, waypoints.Count - i - 1)];
                DirectionsRequestOptions directionsRequestOptions = new DirectionsRequestOptions(options.Uri);
                requestOptions.Add(directionsRequestOptions.SetOrigin(requestOrigin.Location).SetWaypoints(requestWaypoints).SetDestination(requestDestination.Location));
            }

            return requestOptions;
        }
    }
}
