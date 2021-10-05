using System.Collections.Generic;
using System.Linq;
using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions
{
    /// <summary>
    /// <see cref="DirectionsResult" /> represents a result from the Google Maps Directions Web Service.
    /// </summary>
    /// <remarks>
    /// See <see href="https://developers.google.com/maps/documentation/directions/overview">
    /// Directions API</see> for more detail.
    /// </remarks>
    public class DirectionsResult
    {
        /// <summary>
        /// Serialization constructor.
        /// </summary>
        public DirectionsResult()
        { }

        /// <summary>
        /// Constructs an instance of the <see cref="DirectionsResult" /> class.
        /// </summary>
        /// <param name="geocodedWaypoints">A collection of <see cref="GeocodedWaypoint" />.</param>
        /// <param name="routes">A collection of <see cref="DirectionsRoute" />.</param>
        public DirectionsResult(List<GeocodedWaypoint> geocodedWaypoints, List<DirectionsRoute> routes)
        {
            GeocodedWaypoints = geocodedWaypoints;
            Routes = routes;
        }

        /// <summary>
        /// Details about the geocoding of origin, destination, and waypoints.
        /// </summary>
        /// <remarks>
        /// See <see
        /// href="https://developers.google.com/maps/documentation/directions/get-directions#GeocodedWaypoints">Geocoded
        /// Waypoints</see> for more detail.
        /// </remarks>
        [JsonProperty("geocoded_waypoints")]
        public List<GeocodedWaypoint> GeocodedWaypoints { get; } = new List<GeocodedWaypoint>();

        /// <summary>
        /// A collection of <see cref="DirectionsRoute" /> from the origin to the destination.
        /// </summary>
        /// <remarks>
        /// See <see
        /// href="https://developers.google.com/maps/documentation/directions/get-directions#Routes">Routes</see>
        /// for more detail.
        /// </remarks>
        [JsonProperty("routes")]
        public List<DirectionsRoute> Routes { get; } = new List<DirectionsRoute>();

        internal static DirectionsResult Merge(DirectionsResult a, DirectionsResult b)
        {
            var geocodedWaypoints = a.GeocodedWaypoints.Concat(b.GeocodedWaypoints).ToList();
            List<DirectionsRoute> directionsRoutes = new List<DirectionsRoute>();

            for (int i = 0; i < a.Routes.Count || i == 0; i++)
            {
                for (int j = 0; j < b.Routes.Count || j == 0; j++)
                {
                    directionsRoutes.Add(DirectionsRoute.Merge(a.Routes[i], b.Routes[j]));
                }
            }

            return new DirectionsResult(geocodedWaypoints, directionsRoutes);
        }
    }
}
