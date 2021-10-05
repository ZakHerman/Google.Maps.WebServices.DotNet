using System.Runtime.Serialization;

namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// Units of measurement.
    /// </summary>
    /// <remarks>
    /// See <see
    /// href="https://developers.google.com/maps/documentation/directions/get-directions#unit-systems">Unit
    /// Systems</see> for more detail.
    /// </remarks>
    public enum Unit
    {
        /// <summary>
        /// Specifies usage of the metric system.
        /// </summary>
        /// <remarks>Textual distances are returned using kilometers and meters.</remarks>
        [EnumMember(Value = "metric")]
        Metric,

        /// <summary>
        /// Specifies usage of the Imperial system.
        /// </summary>
        /// <remarks>Textual distances are returned using miles and feet.</remarks>
        [EnumMember(Value = "imperial")]
        Imperial
    }
}
