using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Maps.WebServices.Directions;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.DistanceMatrix
{
    /// <summary>
    /// A complete result from a Distance Matrix Web Service call.
    /// </summary>
    public class DistanceMatrixResult
    {
        /// <summary>
        /// Serialization constructor.
        /// </summary>
        public DistanceMatrixResult()
        { }

        /// <summary>
        /// Constructs an instance of the <see cref="DistanceMatrixResult" /> class.
        /// </summary>
        /// <param name="originAddresses"></param>
        /// <param name="destinationAddresses"></param>
        /// <param name="rows"></param>
        public DistanceMatrixResult(IEnumerable<string> originAddresses, IEnumerable<string> destinationAddresses, IEnumerable<DistanceMatrixRow> rows)
        {
            OriginAddresses = originAddresses;
            DestinationAddresses = destinationAddresses;
            Rows = rows;
        }

        /// <summary>
        /// Destination addresses as returned by the Distance Matrix Web Service from the original request.
        /// </summary>
        [JsonProperty("destination_addresses")]
        public IEnumerable<string> DestinationAddresses { get; } = new List<string>();

        /// <summary>
        /// Origin addresses as returned by the Distance Matrix Web Service from the original request.
        /// </summary>
        [JsonProperty("origin_addresses")]
        public IEnumerable<string> OriginAddresses { get; } = new List<string>();

        /// <summary>
        /// A collection of elements, each of which in turn contains a status, duration, and
        /// distance element.
        /// </summary>
        [JsonProperty("rows")]
        public IEnumerable<DistanceMatrixRow> Rows { get; } = new List<DistanceMatrixRow>();

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder($"[{nameof(DirectionsRoute)}:");

            sb.Append($" {OriginAddresses.Count()} Origin(s) x {DestinationAddresses.Count()} Destination(s)");
            sb.Append($", {Rows.Count()} Row(s)");

            return sb.Append(']').ToString();
        }
    }
}
