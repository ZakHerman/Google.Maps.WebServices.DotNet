using System.Runtime.Serialization;

namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// You may specify the transportation mode to use for calulating directions.
    /// </summary>
    /// <remarks>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/directions/get-directions#TravelModes">Directions
    /// API travel modes</see> for more detail.
    /// </remarks>
    public enum TravelMode
    {
        /// <summary>
        /// Indicates an unknown travel mode returned by the server.
        /// </summary>
        [EnumMember(Value = "UNKNOWN")]
        Unknown,

        /// <summary>
        /// Indicates standard driving directions using the road network.
        /// </summary>
        [EnumMember(Value = "DRIVING")]
        Driving,

        /// <summary>
        /// Requests walking directions via pedestrian paths and sidewalks (where available).
        /// </summary>
        [EnumMember(Value = "WALKING")]
        Walking,

        /// <summary>
        /// Requests bicycling directions via bicycle paths and preferred streets (where available).
        /// </summary>
        [EnumMember(Value = "BICYCLING")]
        Bicycling,

        /// <summary>
        /// Requests directions via public transit routes (where available).
        /// </summary>
        [EnumMember(Value = "TRANSIT")]
        Transit
    }
}
