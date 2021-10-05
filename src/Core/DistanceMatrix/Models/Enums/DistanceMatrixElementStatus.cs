using System.Runtime.Serialization;

namespace Google.Maps.WebServices.DistanceMatrix
{
    /// <summary>
    /// The status result for a single <see cref="DistanceMatrixElement" />.
    /// </summary>
    public enum DistanceMatrixElementStatus
    {
        /// <summary>
        /// Indicates an unknown status.
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates that the response contains a valid result.
        /// </summary>
        [EnumMember(Value = "OK")]
        Ok,

        /// <summary>
        /// Indicates that the origin and/or destination of this pairing could not be geocoded.
        /// </summary>
        [EnumMember(Value = "NOT_FOUND")]
        NotFound,

        /// <summary>
        /// Indicates that no route could be found between the origin and destination.
        /// </summary>
        [EnumMember(Value = "ZERO_RESULTS")]
        ZeroResults,

        /// <summary>
        /// Indicates the requested route is too long and cannot be processed.
        /// </summary>
        [EnumMember(Value = "MAX_ROUTE_LENGTH_EXCEEDED")]
        MaxRouteLengthExceeded
    }
}
