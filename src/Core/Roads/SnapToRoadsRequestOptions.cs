using System;
using System.Collections.Generic;
using Google.Maps.WebServices.Common;

namespace Google.Maps.WebServices.Roads
{
    /// <summary>
    /// A request builder class for the snap to roads web service.
    /// </summary>
    public class SnapToRoadsRequestOptions : GoogleMapsRequestOptions<SnapToRoadsRequestOptions>
    {
        private const string RoadsUrlHost = "https://roads.googleapis.com";
        private const string RoadsUrlPath = "/v1/snapToRoads";

        /// <summary>
        /// Constructs an instance of the <see cref="SnapToRoadsRequestOptions" /> class.
        /// </summary>
        public SnapToRoadsRequestOptions() : base(RoadsUrlHost, RoadsUrlPath)
        { }

        /// <summary>
        /// Constructs an instance of the <see cref="SnapToRoadsRequestOptions" /> class.
        /// </summary>
        /// <param name="path">The path to be snapped.</param>
        internal SnapToRoadsRequestOptions(IEnumerable<LatLngLiteral> path) : base(RoadsUrlHost, RoadsUrlPath)
        {
            if (path is null)
                throw new ArgumentNullException(nameof(path));

            SetPath(path);
        }

        /// <summary>
        /// Interpolate a path to include all points forming the full road-geometry.
        /// </summary>
        /// <remarks>
        /// When true, additional interpolated points will also be returned, resulting in a path
        /// that smoothly follows the geometry of the road, even around corners and through tunnels.
        /// </remarks>
        /// <param name="interpolate">Indicates whether to interpolate the path.</param>
        /// <returns>Returns this <see cref="SnapToRoadsRequestOptions" /> for call chaining.</returns>
        public SnapToRoadsRequestOptions InterpolatePath(bool interpolate = true)
        {
            return SetQueryParameter("interpolate", interpolate.ToString());
        }

        internal SnapToRoadsRequestOptions SetPath(IEnumerable<LatLngLiteral> path)
        {
            return SetQueryParameter("path", string.Join("|", path));
        }
    }
}
