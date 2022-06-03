﻿using System.Collections.Generic;
using Google.Maps.WebServices.Common;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions
{
    /// <summary>
    /// <see cref="DirectionsResult" /> represents a result from the Google Maps Directions Web Service.
    /// </summary>
    /// <remarks>
    /// See <see href="https://developers.google.com/maps/documentation/directions/get-directions#DirectionsResponse">
    /// DirectionsResponse</see> for more detail.
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
        /// <param name="availableTravelModes">A collection of <see cref="TravelMode" />.</param>
        /// <param name="geocodedWaypoints">A collection of <see cref="DirectionsGeocodedWaypoint" />.</param>
        /// <param name="routes">A collection of <see cref="DirectionsRoute" />.</param>
        public DirectionsResult(List<TravelMode> availableTravelModes, List<DirectionsGeocodedWaypoint> geocodedWaypoints, List<DirectionsRoute> routes)
        {
            AvailableTravelModes = availableTravelModes;
            GeocodedWaypoints = geocodedWaypoints;
            Routes = routes;
        }

        /// <summary>
        /// Contains a collection of available travel modes.
        /// </summary>
        /// <remarks>
        /// This field is returned when a request specifies a travel mode and gets no results.<br/>
        /// The collection contains the available travel modes in the countries of the given set of waypoints.<br/>
        /// This field is not returned if one or more of the waypoints are 'via waypoints'.<br/>
        /// See <see
        /// href="https://developers.google.com/maps/documentation/directions/get-directions#TravelMode">Geocoded
        /// Waypoints</see> for more detail.
        /// </remarks>
        [JsonProperty("available_travel_modes")]
        public List<TravelMode> AvailableTravelModes { get; } = new List<TravelMode>();

        /// <summary>
        /// Details about the geocoding of origin, destination, and waypoints.
        /// </summary>
        /// <remarks>
        /// See <see
        /// href="https://developers.google.com/maps/documentation/directions/get-directions#DirectionsGeocodedWaypoint">Geocoded
        /// Waypoints</see> for more detail.
        /// </remarks>
        [JsonProperty("geocoded_waypoints")]
        public List<DirectionsGeocodedWaypoint> GeocodedWaypoints { get; } = new List<DirectionsGeocodedWaypoint>();

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
    }
}
