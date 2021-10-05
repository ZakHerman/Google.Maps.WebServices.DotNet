using System.Text;
using Newtonsoft.Json;

namespace Google.Maps.WebServices.Common
{
    /// <summary>
    /// A <see cref="PlusCode" /> (see <see
    /// href="https://en.wikipedia.org/wiki/Open_Location_Code">Open Location Code</see> and <see
    /// href="https://maps.google.com/pluscodes/">plus codes</see>) is an encoded location
    /// reference, derived from latitude and longitude coordinates, that represents an area:
    /// 1/8000th of a degree by 1/8000th of a degree (about 14m x 14m at the equator) or smaller.
    /// </summary>
    /// <remarks>
    /// Plus codes can be used as a replacement for street addresses in places where they do not
    /// exist (where buildings are not numbered or streets are not named).
    /// </remarks>
    public class PlusCode
    {
        /// <summary>
        /// The compound <see cref="PlusCode" /> identifier.
        /// </summary>
        /// <remarks>
        /// <see cref="CompoundCode" /> is a 6 character or longer local code with an explicit
        /// location (CWC8+R9, Mountain View, CA, USA). May be null for locations in remote areas.
        /// </remarks>
        [JsonProperty("compound_code")]
        public string CompoundCode { get; set; }

        /// <summary>
        /// The global <see cref="PlusCode" /> identifier.
        /// </summary>
        /// <remarks>
        /// <see cref="GlobalCode" /> is a 4 character area code and 6 character or longer local
        /// code (849VCWC8+R9).
        /// </remarks>
        [JsonProperty("global_code")]
        public string GlobalCode { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder($"[{nameof(PlusCode)}:");

            sb.Append($" {nameof(GlobalCode)} = {GlobalCode}");
            sb.Append($", {nameof(CompoundCode)} = {CompoundCode}");

            return sb.Append(']').ToString();
        }
    }
}
