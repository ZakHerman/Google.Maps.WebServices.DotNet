using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Google.Maps.WebServices.Common;

namespace Google.Maps.WebServices.Roads
{
    /// <summary>
    /// The Google Maps Roads Web Services identifies the roads a vehicle was traveling along and
    /// provides additional metadata about those roads.
    /// </summary>
    /// <remarks>
    /// See <see href="https://developers.google.com/maps/documentation/roads/overview">Roads
    /// documentation</see> for more detail.
    /// </remarks>
    public static class RoadsService
    {
        /// <summary>
        /// Takes up to 100 independent coordinates, and returns the closest road segment for each point.
        /// </summary>
        /// <remarks>The points passed do not need to be part of a continuous path.</remarks>
        /// <param name="client">
        /// The instance of <see cref="GoogleMapsServiceClient" /> used to send the request.
        /// </param>
        /// <param name="points">The sequence of points to be aligned to nearest roads.</param>
        /// <param name="options">
        /// A <see cref="NearestRoadsRequestOptions" /> used to set additional request query parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>A <see cref="GoogleMapsResponse{T}" /> of the snapped points.</returns>
        public static Task<GoogleMapsResponse<IEnumerable<SnappedPointResult>>> NearestRoadsAsync(this GoogleMapsServiceClient client, IReadOnlyList<LatLngLiteral> points,
                    NearestRoadsRequestOptions options = null, CancellationToken cancellationToken = default)
        {
            options = options?.SetPoints(points) ?? new NearestRoadsRequestOptions(points);
            return client.GetAsync<NearestRoadsRequestOptions, NearestRoadsServiceResponse, IEnumerable<SnappedPointResult>>(options, cancellationToken);
        }

        /// <summary>
        /// Takes up to 100 GPS points collected along a route, and returns a similar set of data
        /// with the points snapped to the most likely roads the vehicle was traveling along.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Additionally, you can request that the points be interpolated, resulting in a path that
        /// smoothly follows the geometry of the road.
        /// </para>
        /// <para>
        /// The snapping algorithm works best for points that are not too far apart. If you observe
        /// odd snapping behavior, try creating paths that have points closer together.
        /// </para>
        /// <para>
        /// To ensure the best snap-to-road quality, you should aim to provide paths on which
        /// consecutive pairs of points are within 300m of each other. This will also help in
        /// handling any isolated, long jumps between consecutive points caused by GPS signal loss,
        /// or noise.
        /// </para>
        /// </remarks>
        /// <param name="client">
        /// The instance of <see cref="GoogleMapsServiceClient" /> used to send the request.
        /// </param>
        /// <param name="path">The path to be snapped.</param>
        /// <param name="options">
        /// A <see cref="SnapToRoadsRequestOptions" /> used to set additional request query parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>A <see cref="GoogleMapsResponse{T}" /> of the snapped points.</returns>
        public static Task<GoogleMapsResponse<IEnumerable<SnappedPointResult>>> SnapToRoadsAsync(this GoogleMapsServiceClient client, IReadOnlyList<LatLngLiteral> path,
            SnapToRoadsRequestOptions options = null, CancellationToken cancellationToken = default)
        {
            options = options?.SetPath(path) ?? new SnapToRoadsRequestOptions(path);
            return client.GetAsync<SnapToRoadsRequestOptions, SnapToRoadsServiceResponse, IEnumerable<SnappedPointResult>>(options, cancellationToken);
        }
    }
}
