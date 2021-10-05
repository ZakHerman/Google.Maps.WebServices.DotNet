using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// A place on Earth, represented by a latitude/longitude pair.
    /// </summary>
    public class LatLng : IUrlValue, IEquatable<LatLng>
    {
        /// <summary>
        /// Serialization constructor.
        /// </summary>
        public LatLng()
        { }

        /// <summary>
        /// Constructs a location with a latitude/longitude pair.
        /// </summary>
        /// <param name="latitude">The latitude of this location.</param>
        /// <param name="longitude">The longitude of this location.</param>
        public LatLng(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// The latitude of this location.
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// The longitude of this location.
        /// </summary>
        [JsonProperty("lng")]
        public double Longitude { get; set; }

        /// <summary>
        /// The latitude of this location.
        /// </summary>
        /// <remarks>A write only property for when JSON field is "latitude".</remarks>
        [JsonProperty("latitude")]
        private double RoadsLatitude
        {
            set => Latitude = value;
        }

        /// <summary>
        /// The longitude of this location.
        /// </summary>
        /// <remarks>A write only property for when JSON field is "longitude".</remarks>
        [JsonProperty("longitude")]
        private double RoadsLongitude
        {
            set => Longitude = value;
        }

        /// <inheritdoc />
        public bool Equals(LatLng other)
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
