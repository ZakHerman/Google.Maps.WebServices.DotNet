using System;
using System.Collections.Generic;
using Google.Maps.WebServices.Util;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// Encoded polylines are used by the API to represent paths.
    /// </summary>
    /// <remarks>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/utilities/polylinealgorithm">Encoded
    /// Polyline Algorithm</see> for more detail on the protocol.
    /// </remarks>
    public class EncodedPolyline
    {
        /// <summary>
        /// A string representation of a path, encoded with the Polyline Algorithm.
        /// </summary>
        [JsonProperty("points")]
        public string Points { get; set; }

        /// <inheritdoc />
        public override string ToString() => $"[{nameof(EncodedPolyline)}: {Points}]";

        internal static EncodedPolyline Merge(params EncodedPolyline[] encodedPolylines)
        {
            if (encodedPolylines is null)
                throw new ArgumentNullException(nameof(encodedPolylines));

            List<LatLng> points = new List<LatLng>();

            foreach (EncodedPolyline encodedPolyline in encodedPolylines)
            {
                if (encodedPolyline?.Points != null)
                    points.AddRange(PolylineEncoding.Decode(encodedPolyline.Points));
            }

            return new EncodedPolyline
            {
                Points = PolylineEncoding.Encode(points)
            };
        }
    }
}
