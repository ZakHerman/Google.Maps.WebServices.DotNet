using System;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// A rectangle in geographical coordinates from points at the southwest and northeast corners.
    /// </summary>
    public class Bounds
    {
        /// <summary>
        /// The northeast corner of the bounding box.
        /// </summary>
        [JsonProperty("northeast")]
        public LatLngLiteral NorthEast { get; set; }

        /// <summary>
        /// The southwest corner of the bounding box.
        /// </summary>
        [JsonProperty("southwest")]
        public LatLngLiteral SouthWest { get; set; }

        /// <summary>
        /// Merge two <see cref="Bounds" /> together.
        /// </summary>
        /// <param name="a">The first <see cref="Bounds" />.</param>
        /// <param name="b">The second <see cref="Bounds" />.</param>
        /// <returns>The combined <see cref="Bounds" />.</returns>
        public static Bounds Merge(Bounds a, Bounds b)
        {
            if (a?.NorthEast is null && b?.NorthEast is null)
                throw new ArgumentException($"Both bounds '{nameof(NorthEast)}' value are null.");

            if (a?.SouthWest is null && b?.SouthWest is null)
                throw new ArgumentException($"Both bounds '{nameof(SouthWest)}' value are null.");

            return new Bounds
            {
                NorthEast = new LatLngLiteral
                {
                    Latitude = a?.NorthEast?.Latitude.CompareTo(b?.NorthEast?.Latitude) > 0
                        ? a.NorthEast.Latitude
                        : b?.NorthEast?.Latitude ?? a.NorthEast.Latitude,
                    Longitude = a?.NorthEast?.Longitude.CompareTo(b?.NorthEast?.Longitude) > 0
                        ? a.NorthEast.Longitude
                        : b?.NorthEast?.Longitude ?? a.NorthEast.Longitude
                },
                SouthWest = new LatLngLiteral
                {
                    Latitude = a?.SouthWest?.Latitude.CompareTo(b?.SouthWest?.Latitude) < 0
                        ? a.SouthWest.Latitude
                        : b?.SouthWest?.Latitude ?? a.SouthWest.Latitude,
                    Longitude = a?.SouthWest?.Longitude.CompareTo(b?.SouthWest?.Longitude) < 0
                        ? a.SouthWest.Longitude
                        : b?.SouthWest?.Longitude ?? a.SouthWest.Longitude
                }
            };
        }

        /// <inheritdoc />
        public override string ToString() => $"[{NorthEast}, {SouthWest}]";
    }
}
