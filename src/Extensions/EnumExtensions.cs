using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Google.Maps.WebServices.Extensions
{
    internal static class EnumExtensions
    {
        internal static string ToUriValue(this Enum @enum)
        {
            return JsonConvert.SerializeObject(@enum, new StringEnumConverter()).Replace("\"", "");
        }
    }
}
