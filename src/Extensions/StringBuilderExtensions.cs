using System.Collections.Generic;
using System.Text;

namespace Google.Maps.WebServices.Extensions
{
    internal static class StringBuilderExtensions
    {
        /// <summary>
        /// Concatenates and appends the members of a collection, using the specified separator
        /// between each member.
        /// </summary>
        /// <typeparam name="T">The type of the members of <paramref name="values" />.</typeparam>
        /// <param name="stringBuilder">The <see cref="StringBuilder" /> to act on.</param>
        /// <param name="separator">
        /// The string to use as a separator. separator is included in the concatenated and appended
        /// strings only if values has more than one element.
        /// </param>
        /// <param name="values">
        /// A collection that contains the objects to concatenate and append to the current instance
        /// of the string builder.
        /// </param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        internal static StringBuilder AppendJoin<T>(this StringBuilder stringBuilder, string separator, IEnumerable<T> values)
        {
            return stringBuilder.Append(string.Join(separator, values));
        }
    }
}
