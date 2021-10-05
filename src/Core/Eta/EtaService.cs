using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Maps.WebServices.Directions;
using Google.Maps.WebServices.Extensions;

namespace Google.Maps.WebServices.Eta
{
    /// <summary>
    /// </summary>
    public static class EtaService
    {
        public static Task<List<EtaResult>> CalculateEtaAsync(this GoogleMapsServiceClient client, EtaWaypoint origin, EtaWaypoint destination, DateTime scheduledStartTime,
            IEnumerable<EtaWaypoint> waypoints = null, EtaRequestOptions options = null, CancellationToken cancellationToken = default)
        {
            if (origin is null)
                throw new ArgumentNullException(nameof(origin));

            if (destination is null)
                throw new ArgumentNullException(nameof(destination));

            List<EtaWaypoint> stops = GetAllWaypoints(origin, destination, waypoints);

            return CalculateEtaAsync(client, stops, scheduledStartTime, options, cancellationToken);
        }

        public static async Task<List<EtaResult>> CalculateEtaAsync(this GoogleMapsServiceClient client, IEnumerable<EtaWaypoint> waypoints, DateTime scheduledStartTime,
            EtaRequestOptions options = null, CancellationToken cancellationToken = default)
        {
            if (waypoints is null)
                throw new ArgumentNullException(nameof(waypoints));

            var stops = waypoints.ToList();
            var directionsLegs = new List<DirectionsLeg>();
            var results = new List<EtaResult>();

            for (int i = 0; i < stops.Count; i++)
            {
                long duration = i == 0 ? 0 : directionsLegs[i - 1].DurationInTraffic?.Seconds ?? directionsLegs[i - 1].Duration.Seconds;
                DateTime arrivalTime = i == 0 ? scheduledStartTime : results[i - 1].DepartureDateTimeUtc.AddSeconds(duration);
                TimeSpan serviceTime = stops[i].ServiceTime;
                DateTime departureTime = arrivalTime.Add(serviceTime);

                if (i < stops.Count - 1)
                {
                    var request = new DirectionsRequestOptions();

                    // 'departure_time' must be set to the current time or some time in the future.
                    // It cannot be in the past.
                    if (departureTime >= DateTime.UtcNow)
                        request.SetDepartureTime(departureTime);

                    try
                    {
                        // Make separate directions API call for each leg.
                        DirectionsResult directionsResult = await client.GetDirectionsAsync(stops[i].Location, stops[i + 1].Location, request, cancellationToken);
                        directionsLegs.Add(directionsResult.Routes[0].Legs[0]);
                    }
                    catch (Exception)
                    {
                        // TODO: Add logging of exception
                        break;
                    }
                }

                var result = new EtaResult
                {
                    Address = i == stops.Count - 1 ? directionsLegs[i - 1].EndAddress : directionsLegs[i].StartAddress,
                    Location = i == stops.Count - 1 ? directionsLegs[i - 1].EndLocation : directionsLegs[i].StartLocation,
                    ArrivalDateTimeUtc = arrivalTime,
                    ServiceTime = serviceTime,
                    DepartureDateTimeUtc = departureTime
                };

                results.Add(result);
            }

            return results;
        }

        private static List<EtaWaypoint> GetAllWaypoints(EtaWaypoint origin, EtaWaypoint destination, IEnumerable<EtaWaypoint> waypoints)
        {
            var legs = new List<EtaWaypoint>();

            legs.Add(origin);

            if (waypoints != null)
                legs.AddRange(waypoints.ToICollection());

            legs.Add(destination);

            return legs;
        }
    }
}
