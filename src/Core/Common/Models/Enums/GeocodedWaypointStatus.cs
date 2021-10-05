﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// The status result for a single <see cref="GeocodedWaypoint" />.
    /// </summary>
    /// <remarks>
    /// See <a
    /// href="https://developers.google.com/maps/documentation/directions/get-directions#StatusCodes">Status
    /// Codes</a> for more detail.
    /// </remarks>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeocodedWaypointStatus
    {
        /// <summary>
        /// Indicates an unknown error.
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates the response contains a valid result.
        /// </summary>
        [EnumMember(Value = "OK")]
        Ok,

        /// <summary>
        /// Indicates no route could be found between the origin and destination.
        /// </summary>
        [EnumMember(Value = "ZERO_RESULTS")]
        ZeroResults
    }
}
