using System;
using System.Collections.Generic;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Util;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Directions
{
    /// <summary>
    /// Contains an object that holds an encoded polyline representation of the route.
    /// </summary>
    /// <remarks>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/directions/get-directions#DirectionsPolyline">Encoded
    /// DirectionsPolyline</see> for more detail.
    /// </remarks>
    public class DirectionsPolyline
    {
        /// <summary>
        /// A single string representation of the polyline.
        /// </summary>
        [JsonProperty("points")]
        public string Points { get; set; }

        /// <inheritdoc />
        public override string ToString() => $"[{nameof(DirectionsPolyline)}: {Points}]";
    }
}
