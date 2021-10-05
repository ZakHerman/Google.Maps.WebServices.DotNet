using System.Collections.Generic;
using System.Text;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Extensions;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Geocoding
{
    /// <summary>
    /// A result from a Geocoding API call.
    /// </summary>
    public class GeocodingResult
    {
        /// <summary>
        /// The separate address components in this result.
        /// </summary>
        [JsonProperty("address_components")]
        public List<AddressComponent> AddressComponents { get; } = new List<AddressComponent>();

        /// <summary>
        /// The address types of the returned result.
        /// </summary>
        /// <remarks>
        /// This array contains a set of zero or more tags identifying the type of feature returned
        /// in the result. For example, a geocode of "Chicago" returns <see
        /// cref="AddressType.Locality" /> which indicates that "Chicago" is a city, and also
        /// returns <see cref="AddressType.Political" /> which indicates it is a political entity.
        /// </remarks>
        [JsonProperty("types")]
        public List<AddressType> AddressTypes { get; } = new List<AddressType>();

        /// <summary>
        /// The human-readable address of this location.
        /// </summary>
        /// <remarks>
        /// Often this address is equivalent to the "postal address", which sometimes differs from
        /// country to country. (Note that some countries, such as the United Kingdom, do not allow
        /// distribution of true postal addresses due to licensing restrictions.) This address is
        /// generally composed of one or more address components. For example, the address "111 8th
        /// Avenue, New York, NY" contains separate address components for "111" (the street number,
        /// "8th Avenue" (the route), "New York" (the city) and "NY" (the US state). These address
        /// components contain additional information.
        /// </remarks>
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        /// <summary>
        /// Location information for this result.
        /// </summary>
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        /// <summary>
        /// Indicates that the geocoder did not return an exact match for the original request,
        /// though it was able to match part of the requested address. You may wish to examine the
        /// original request for misspellings and/or an incomplete address.
        /// </summary>
        /// <remarks>
        /// Partial matches most often occur for street addresses that do not exist within the
        /// locality you pass in the request. Partial matches may also be returned when a request
        /// matches two or more locations in the same locality. For example, "21 Henr St, Bristol,
        /// UK" will return a partial match for both Henry Street and Henrietta Street. Note that if
        /// a request includes a misspelled address component, the geocoding service may suggest an
        /// alternate address. Suggestions triggered in this way will not be marked as a partial match.
        /// </remarks>
        [JsonProperty("partial_match")]
        public bool PartialMatch { get; set; }

        /// <summary>
        /// A unique identifier for this place.
        /// </summary>
        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        /// <summary>
        /// The <see cref="PlusCode" /> identifier for this place.
        /// </summary>
        [JsonProperty("plus_code")]
        public PlusCode PlusCode { get; set; }

        /// <summary>
        /// All the localities contained in a postal code.
        /// </summary>
        /// <remarks>
        /// This is only present when the result is a postal code that contains multiple localities.
        /// </remarks>
        [JsonProperty("postcode_localities")]
        public List<string> PostcodeLocalities { get; } = new List<string>();

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder($"[{nameof(GeocodingResult)}:");

            sb.Append($" {nameof(FormattedAddress)} = {FormattedAddress}");
            sb.Append($", {nameof(PlaceId)} = {PlaceId}");
            sb.Append($", {nameof(PlusCode)} = {PlusCode}");
            sb.Append($", {nameof(PartialMatch)} = {PartialMatch}");
            sb.Append($", {nameof(AddressTypes)} = [").AppendJoin(", ", AddressTypes).Append(']');
            sb.Append($", {nameof(AddressComponents)} = [").AppendJoin(", ", AddressComponents).Append(']');
            sb.Append($", {nameof(Geometry)} = {Geometry}");

            return sb.Append(']').ToString();
        }
    }
}
