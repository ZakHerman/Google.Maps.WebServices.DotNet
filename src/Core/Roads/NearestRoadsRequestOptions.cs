﻿using System;
using System.Collections.Generic;
using Google.Maps.WebServices.Common;

namespace Google.Maps.WebServices.Roads
{
    /// <summary>
    /// A request builder class for the Google Maps Nearest Roads Web Service.
    /// </summary>
    public class NearestRoadsRequestOptions : GoogleMapsRequestOptions<NearestRoadsRequestOptions>
    {
        private const string RoadsUrlHost = "https://roads.googleapis.com";
        private const string RoadsUrlPath = "/v1/nearestRoads";

        /// <summary>
        /// Constructs an instance of the <see cref="NearestRoadsRequestOptions" /> class.
        /// </summary>
        public NearestRoadsRequestOptions() : base(RoadsUrlHost, RoadsUrlPath)
        { }

        /// <summary>
        /// Constructs an instance of the <see cref="NearestRoadsRequestOptions" /> class.
        /// </summary>
        /// <param name="points">The location points to process.</param>
        internal NearestRoadsRequestOptions(IEnumerable<LatLng> points) : base(RoadsUrlHost, RoadsUrlPath)
        {
            if (points is null)
                throw new ArgumentNullException(nameof(points));

            SetPoints(points);
        }

        internal NearestRoadsRequestOptions SetPoints(IEnumerable<LatLng> points)
        {
            return SetQueryParameter("points", string.Join("|", points));
        }
    }
}
