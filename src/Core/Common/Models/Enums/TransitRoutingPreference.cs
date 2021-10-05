using System.Runtime.Serialization;

namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// Indicates user preference when requesting transit directions.
    /// </summary>
    public enum TransitRoutingPreference
    {
        /// <summary>
        /// Indicates that the calculated route should prefer limited amounts of walking.
        /// </summary>
        [EnumMember(Value = "less_walking")]
        LessWalking,

        /// <summary>
        /// Indicates that the calculated route should prefer a limited number of transfers.
        /// </summary>
        [EnumMember(Value = "fewer_transfers")]
        FewerTransfers
    }
}
