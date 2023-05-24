using System;
using System.Collections.Generic;
using System.Text;
using Google.Maps.WebServices.Common;

namespace Google.Maps.WebServices.Utils;

/// <summary>
/// Utility class that encodes and decodes polylines.
/// </summary>
/// <remarks>
/// See <see
/// href="https://developers.google.com/maps/documentation/utilities/polylinealgorithm">Encoded
/// Polyline Algorithm</see> for more detail.
/// </remarks>
public static class PolylineEncoding
{
    /// <summary>
    /// Decodes an encoded path string into a sequence of <see cref="LatLngLiteral" />.
    /// </summary>
    /// <param name="encodedPath">The encoded polyline to be decoded.</param>
    /// <returns>A collection of <see cref="LatLngLiteral" />.</returns>
    public static List<LatLngLiteral> Decode(string encodedPath)
    {
        if (encodedPath is null)
            throw new ArgumentNullException(nameof(encodedPath));

        int len = encodedPath.Length;

        var path = new List<LatLngLiteral>();
        int index = 0;
        int lat = 0;
        int lng = 0;

        while (index < len)
        {
            int result = 1;
            int shift = 0;
            int b;

            do
            {
                b = encodedPath[index++] - 63 - 1;
                result += b << shift;
                shift += 5;
            } while (b >= 0x1f);

            lat += (result & 1) != 0 ? ~(result >> 1) : result >> 1;

            result = 1;
            shift = 0;

            do
            {
                b = encodedPath[index++] - 63 - 1;
                result += b << shift;
                shift += 5;
            } while (b >= 0x1f);

            lng += (result & 1) != 0 ? ~(result >> 1) : result >> 1;

            path.Add(new LatLngLiteral(Math.Round(lat * 1e-5, 5), Math.Round(lng * 1e-5, 5)));
        }

        return path;
    }

    /// <summary>
    /// Encodes a sequence of <see cref="LatLngLiteral" /> into an encoded path string.
    /// </summary>
    /// <param name="path">The collection of <see cref="LatLngLiteral" /> to encode.</param>
    /// <returns>A string representation of an encoded polyline.</returns>
    public static string Encode(IEnumerable<LatLngLiteral> path)
    {
        if (path is null)
            throw new ArgumentNullException(nameof(path));

        long lastLat = 0;
        long lastLng = 0;

        var result = new StringBuilder();

        foreach (LatLngLiteral point in path)
        {
            long lat = (long)Math.Round(point.Latitude * 1e5);
            long lng = (long)Math.Round(point.Longitude * 1e5);

            long dLat = lat - lastLat;
            long dLng = lng - lastLng;

            Encode(dLat, result);
            Encode(dLng, result);

            lastLat = lat;
            lastLng = lng;
        }

        return result.ToString();
    }

    private static void Encode(long v, StringBuilder result)
    {
        v = v < 0 ? ~(v << 1) : v << 1;

        while (v >= 0x20)
        {
            result.Append((char)((0x20 | (v & 0x1f)) + 63));
            v >>= 5;
        }

        result.Append((char)(v + 63));
    }
}
