using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// An object describing a specific location with latitude and longitude in decimal degrees.
    /// </summary>
    public class LatLngLiteral : IUrlValue, IEquatable<LatLngLiteral>
    {
        /// <summary>
        /// Serialization constructor.
        /// </summary>
        public LatLngLiteral()
        { }

        /// <summary>
        /// Constructs a location with a latitude/longitude pair.
        /// </summary>
        /// <param name="latitude">The latitude of this location.</param>
        /// <param name="longitude">The longitude of this location.</param>
        public LatLngLiteral(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Latitude in decimal degrees.
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude in decimal degrees.
        /// </summary>
        [JsonProperty("lng")]
        public double Longitude { get; set; }

        /// <summary>
        /// Latitude in decimal degrees.
        /// </summary>
        /// <remarks>A write only property for when JSON field is "latitude".</remarks>
        [JsonProperty("latitude")]
        private double RoadsLatitude
        {
            set => Latitude = value;
        }

        /// <summary>
        /// Longitude in decimal degrees.
        /// </summary>
        /// <remarks>A write only property for when JSON field is "longitude".</remarks>
        [JsonProperty("longitude")]
        private double RoadsLongitude
        {
            set => Longitude = value;
        }

        /// <inheritdoc />
        public bool Equals(LatLngLiteral other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return ToUriValue();
        }

        /// <inheritdoc />
        public string ToUriValue()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0},{1}", Latitude, Longitude);
        }
    }
}
