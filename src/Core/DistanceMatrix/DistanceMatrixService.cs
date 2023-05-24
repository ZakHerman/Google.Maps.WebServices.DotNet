using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Google.Maps.WebServices.Common;

namespace Google.Maps.WebServices.DistanceMatrix;

/// <summary>
/// The Distance Matrix Web Service is a service that provides travel distance and time for a
/// matrix of origins and destinations.
/// </summary>
/// <remarks>
/// The information returned is based on the recommended route between start and end points, as
/// calculated by the Google Maps Web Service, and consists of rows containing duration and
/// distance values for each pair.
/// </remarks>
public static class DistanceMatrixService
{
    /// <summary>
    /// Requests the travel distance and time between the given matrix of <paramref
    /// name="origins" /> and <paramref name="destinations" />.
    /// </summary>
    /// <param name="client">
    /// The instance of <see cref="GoogleMapsServiceClient" /> used to send the request.
    /// </param>
    /// <param name="origins">The locations used as origin points.</param>
    /// <param name="destinations">The locations used as destination points.</param>
    /// <param name="options">
    /// A <see cref="DistanceMatrixRequestOptions" /> used to set optional query parameters.
    /// </param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>A <see cref="GoogleMapsResponse{DistanceMatrixResult}" />.</returns>
    public static Task<GoogleMapsResponse<DistanceMatrixResult>> GetDistanceMatrixAsync(this GoogleMapsServiceClient client, List<string> origins,
        List<string> destinations, DistanceMatrixRequestOptions options = null, CancellationToken cancellationToken = default)
    {
        options = options?.SetOrigins(origins).SetDestinations(destinations) ?? new DistanceMatrixRequestOptions(origins, destinations);

        return client.GetAsync<DistanceMatrixRequestOptions, DistanceMatrixServiceResponse, DistanceMatrixResult>(options, cancellationToken);
    }
}
