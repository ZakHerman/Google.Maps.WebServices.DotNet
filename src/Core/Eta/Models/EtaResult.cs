using System;
using Google.Maps.WebServices.Common;

namespace Google.Maps.WebServices.Eta
{
    public class EtaResult
    {
        /// <summary>
        /// The human-readable address (typically a street address) reflecting the location.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The latitude/longitude coordinates.
        /// </summary>
        public LatLng Location { get; set; }

        public DateTime ArrivalDateTimeUtc { get; set; }

        public TimeSpan ServiceTime { get; set; }

        public DateTime DepartureDateTimeUtc { get; set; }
    }
}
