using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Directions;
using Google.Maps.WebServices.Tests.TestHelpers;
using Xunit;

namespace Google.Maps.WebServices.Tests.Core.Directions
{
    public class DirectionsServiceTests
    {
        private readonly HttpClientFixture _httpClientFixture;

        public DirectionsServiceTests()
        {
            _httpClientFixture = new HttpClientFixture();
        }

        [Fact]
        public async Task GetDirectionsAsync_WithDirectionsResponseJson_HasValidBounds()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("DirectionsResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);

            // Act
            GoogleMapsResponse<DirectionsResult> response = await googleMapsClient.GetDirectionsAsync("ORIGIN_TEST", "DESTINATION_TEST");
            Bounds bounds = response.Result.Routes[0].Bounds;

            // Assert
            Assert.NotNull(bounds);
            Assert.NotNull(bounds.NorthEast);
            Assert.NotNull(bounds.SouthWest);
            Assert.Equal(-36.849036, bounds.NorthEast.Latitude);
            Assert.Equal(174.8409792, bounds.NorthEast.Longitude);
            Assert.Equal(-36.9263368, bounds.SouthWest.Latitude);
            Assert.Equal(174.7640208, bounds.SouthWest.Longitude);
        }

        [Fact]
        public async Task GetDirectionsAsync_WithDirectionsResponseJson_HasValidDirectionsLegs()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("DirectionsResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);

            // Act
            GoogleMapsResponse<DirectionsResult> response = await googleMapsClient.GetDirectionsAsync("ORIGIN_TEST", "DESTINATION_TEST");
            List<DirectionsLeg> directionsLegs = response.Result.Routes[0].Legs;

            // Assert
            Assert.Single(directionsLegs);
            Assert.NotNull(directionsLegs[0].Distance);
            Assert.Equal("12.5 km", directionsLegs[0].Distance.DisplayValue);
            Assert.Equal(12546, directionsLegs[0].Distance.Meters);
            Assert.NotNull(directionsLegs[0].Duration);
            Assert.Equal("16 mins", directionsLegs[0].Duration.DisplayValue);
            Assert.Equal(948, directionsLegs[0].Duration.Seconds);
            Assert.Null(directionsLegs[0].DurationInTraffic);
            Assert.NotNull(directionsLegs[0].StartLocation);
            Assert.Equal(-36.9259529, directionsLegs[0].StartLocation.Latitude);
            Assert.Equal(174.8390865, directionsLegs[0].StartLocation.Longitude);
            Assert.Equal("8 Westfield Place, Auckland 1060, New Zealand", directionsLegs[0].StartAddress);
            Assert.NotNull(directionsLegs[0].EndLocation);
            Assert.Equal(-36.8494036, directionsLegs[0].EndLocation.Latitude);
            Assert.Equal(174.7651721, directionsLegs[0].EndLocation.Longitude);
            Assert.Equal("228 Queen Street, Auckland CBD, Auckland 1010, New Zealand", directionsLegs[0].EndAddress);
        }

        [Fact]
        public async Task GetDirectionsAsync_WithDirectionsResponseJson_HasValidDirectionsResponse()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("DirectionsResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);

            // Act
            GoogleMapsResponse<DirectionsResult> response = await googleMapsClient.GetDirectionsAsync("ORIGIN_TEST", "DESTINATION_TEST");

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccessful);
            Assert.Equal(ApiResponseStatus.Ok, response.ResponseStatus);
            Assert.Null(response.ErrorMessage);
        }

        [Fact]
        public async Task GetDirectionsAsync_WithDirectionsResponseJson_HasValidDirectionsResult()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("DirectionsResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);

            // Act
            GoogleMapsResponse<DirectionsResult> response = await googleMapsClient.GetDirectionsAsync("ORIGIN_TEST", "DESTINATION_TEST");
            DirectionsResult directionsResult = response.Result;

            // Assert
            Assert.NotNull(directionsResult);
        }

        [Fact]
        public async Task GetDirectionsAsync_WithDirectionsResponseJson_HasValidDirectionsRoutes()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("DirectionsResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);

            // Act
            GoogleMapsResponse<DirectionsResult> response = await googleMapsClient.GetDirectionsAsync("ORIGIN_TEST", "DESTINATION_TEST");
            List<DirectionsRoute> directionsRoutes = response.Result.Routes;

            // Assert
            Assert.NotNull(directionsRoutes);
            Assert.NotNull(directionsRoutes.FirstOrDefault());
            Assert.Single(directionsRoutes);
            Assert.Equal("State Hwy 1", directionsRoutes[0].Summary);
            Assert.NotNull(directionsRoutes[0].OverviewPolyline);
            Assert.StartsWith("dbk`Figcj`@h@pBTvBLx@uD|@g@Ba@Cy@Ym@", directionsRoutes[0].OverviewPolyline.Points);
            Assert.NotNull(directionsRoutes[0].WaypointOrder);
            Assert.NotNull(directionsRoutes[0].Warnings);
            Assert.Empty(directionsRoutes[0].Warnings);
            Assert.NotNull(directionsRoutes[0].Copyrights);
            Assert.Equal("Map data ©2021", directionsRoutes[0].Copyrights);
        }

        [Fact]
        public async Task GetDirectionsAsync_WithDirectionsResponseJson_HasValidDirectionsSteps()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("DirectionsResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);

            // Act
            GoogleMapsResponse<DirectionsResult> response = await googleMapsClient.GetDirectionsAsync("ORIGIN_TEST", "DESTINATION_TEST");
            List<DirectionsStep> directionsSteps = response.Result.Routes.First().Legs.First().Steps;

            // Assert
            Assert.Equal(10, directionsSteps.Count);
            Assert.NotNull(directionsSteps[0].Distance);
            Assert.Equal("0.1 km", directionsSteps[0].Distance.DisplayValue);
            Assert.Equal(137, directionsSteps[0].Distance.Meters);
            Assert.NotNull(directionsSteps[0].Duration);
            Assert.Equal("1 min", directionsSteps[0].Duration.DisplayValue);
            Assert.Equal(45, directionsSteps[0].Duration.Seconds);
            Assert.NotNull(directionsSteps[0].StartLocation);
            Assert.Equal(-36.9259529, directionsSteps[0].StartLocation.Latitude);
            Assert.Equal(174.8390865, directionsSteps[0].StartLocation.Longitude);
            Assert.NotNull(directionsSteps[0].EndLocation);
            Assert.Equal(-36.9263368, directionsSteps[0].EndLocation.Latitude);
            Assert.Equal(174.8376311, directionsSteps[0].EndLocation.Longitude);
            Assert.Null(directionsSteps[0].Maneuver);
            Assert.Equal("turn-right", directionsSteps[1].Maneuver);
            Assert.Equal("Head <b>southwest</b> on <b>Westfield Pl</b> toward <b>Vestey Dr</b>", directionsSteps[0].HtmlInstructions);
            Assert.Equal("dbk`Figcj`@h@pBTvBLx@", directionsSteps[0].PolyLine.Points);
            Assert.NotNull(directionsSteps[0].Steps);
            Assert.Empty(directionsSteps[0].Steps);
            Assert.Equal(TravelMode.Driving, directionsSteps[0].TravelMode);
        }

        [Fact]
        public async Task GetDirectionsAsync_WithDirectionsResponseJson_HasValidGeocodedWaypoints()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("DirectionsResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);

            // Act
            GoogleMapsResponse<DirectionsResult> response = await googleMapsClient.GetDirectionsAsync("ORIGIN_TEST", "DESTINATION_TEST");
            List<GeocodedWaypoint> geocodedWaypoints = response.Result.GeocodedWaypoints;

            // Assert
            Assert.NotNull(geocodedWaypoints);
            Assert.Equal(2, geocodedWaypoints.Count);
            Assert.False(geocodedWaypoints[0].PartialMatch);
            Assert.Equal("Eh44IFdlc3RmaWVsZCBQbGFjZSwgTmV3IFplYWxhbmQiGhIYChQKEglBbdLiSkkNbRHMhXRwat9rtxAI", geocodedWaypoints[0].PlaceId);
            Assert.Equal(4, geocodedWaypoints[0].Types.Count);
            Assert.Contains(AddressType.ColloquialArea, geocodedWaypoints[0].Types);
            Assert.Contains(AddressType.Unknown, geocodedWaypoints[0].Types);
            Assert.Equal(AddressType.Unknown, geocodedWaypoints[0].Types[3]);
            Assert.Equal(GeocodedWaypointStatus.Ok, geocodedWaypoints[0].GeoCoderStatus);
            Assert.Equal("ChIJ_5kb1vpHDW0RENfNoq8OXk8", geocodedWaypoints[1].PlaceId);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(24, 1)]
        [InlineData(25, 1)]
        [InlineData(26, 2)]
        [InlineData(60, 3)]
        [InlineData(99, 4)]
        [InlineData(100, 4)]
        public void SplitDirectionsRequestOptions_WithMultipleWaypoints_HasCorrectCollectionCount(int waypointsCount, int collectionCount)
        {
            // Arrange
            const string origin = "ORIGIN";
            const string destination = "DESTINATION";
            var waypoints = new List<Waypoint>();

            for (int i = 0; i < waypointsCount; i++)
            {
                waypoints.Add(new Waypoint($"WAYPOINT_{i + 1}"));
            }

            DirectionsRequestOptions options = new DirectionsRequestOptions(origin, destination).SetWaypoints(waypoints);

            // Act
            List<DirectionsRequestOptions> requestOptions = DirectionsService.SplitDirectionsRequestOptions(options).ToList();

            // Assert
            Assert.NotNull(requestOptions);
            Assert.Equal(collectionCount, requestOptions.Count);
        }

        [Fact]
        public void SplitDirectionsRequestOptions_With60Waypoints_ReturnsDirectionsRequestOptionsCollection()
        {
            // Arrange
            const string origin = "ORIGIN";
            const string destination = "DESTINATION";
            var waypoints = new List<Waypoint>();

            for (int i = 0; i < 60; i++)
            {
                waypoints.Add(new Waypoint($"WAYPOINT_{i + 1}"));
            }

            DirectionsRequestOptions options = new DirectionsRequestOptions()
                .SetOrigin(origin)
                .SetDestination(destination)
                .SetWaypoints(waypoints)
                .SetTravelMode(TravelMode.Walking)
                .SetTransitRoutingPreference(TransitRoutingPreference.FewerTransfers)
                .SetPreferredRegion("TEST_REGION")
                .SetPreferredUnitSystem(Unit.Metric);

            // Act
            List<DirectionsRequestOptions> requestOptions = DirectionsService.SplitDirectionsRequestOptions(options).ToList();

            // Assert
            Assert.NotNull(requestOptions);
            Assert.Equal("ORIGIN", requestOptions[0].Origin);
            Assert.Equal("WAYPOINT_1", requestOptions[0].Waypoints.FirstOrDefault()?.Location);
            Assert.Equal("WAYPOINT_25", requestOptions[0].Waypoints.LastOrDefault()?.Location);
            Assert.Equal("WAYPOINT_26", requestOptions[0].Destination);
            Assert.Contains("mode", requestOptions[0].Uri.Query);
            Assert.Equal("WALKING", HttpUtility.ParseQueryString(requestOptions[0].Uri.Query).Get("mode"));
            Assert.Contains("transit_routing_preference", requestOptions[0].Uri.Query);
            Assert.Equal("fewer_transfers", HttpUtility.ParseQueryString(requestOptions[0].Uri.Query).Get("transit_routing_preference"));
            Assert.Contains("region", requestOptions[0].Uri.Query);
            Assert.Equal("TEST_REGION", HttpUtility.ParseQueryString(requestOptions[0].Uri.Query).Get("region"));
            Assert.Contains("units", requestOptions[0].Uri.Query);
            Assert.Equal("metric", HttpUtility.ParseQueryString(requestOptions[0].Uri.Query).Get("units"));
            Assert.Equal("WAYPOINT_26", requestOptions[1].Origin);
            Assert.Equal("WAYPOINT_27", requestOptions[1].Waypoints.FirstOrDefault()?.Location);
            Assert.Equal("WAYPOINT_51", requestOptions[1].Waypoints.LastOrDefault()?.Location);
            Assert.Equal("WAYPOINT_52", requestOptions[1].Destination);
            Assert.Equal("WAYPOINT_52", requestOptions[2].Origin);
            Assert.Equal("WAYPOINT_53", requestOptions[2].Waypoints.FirstOrDefault()?.Location);
            Assert.Equal("WAYPOINT_60", requestOptions[2].Waypoints.LastOrDefault()?.Location);
            Assert.Equal("DESTINATION", requestOptions[2].Destination);
        }

        [Fact]
        public void SplitDirectionsRequestOptions_With26Waypoints_ReturnsDirectionsRequestOptionsCollection()
        {
            // Arrange
            const string origin = "ORIGIN";
            const string destination = "DESTINATION";
            var waypoints = new List<Waypoint>();

            for (int i = 0; i < 26; i++)
            {
                waypoints.Add(new Waypoint($"WAYPOINT_{i + 1}"));
            }

            DirectionsRequestOptions options = new DirectionsRequestOptions(origin, destination).SetWaypoints(waypoints);

            // Act
            List<DirectionsRequestOptions> requestOptions = DirectionsService.SplitDirectionsRequestOptions(options).ToList();

            // Assert
            Assert.NotNull(requestOptions);
            Assert.Equal("ORIGIN", requestOptions[0].Origin);
            Assert.Equal("WAYPOINT_1", requestOptions[0].Waypoints.FirstOrDefault()?.Location);
            Assert.Equal("WAYPOINT_25", requestOptions[0].Waypoints.LastOrDefault()?.Location);
            Assert.Equal("WAYPOINT_26", requestOptions[0].Destination);
            Assert.Contains("waypoints", requestOptions[0].Uri.Query);
            Assert.Equal("WAYPOINT_26", requestOptions[1].Origin);
            Assert.Equal("DESTINATION", requestOptions[1].Destination);
            Assert.False(requestOptions[1].Waypoints.Any());
            Assert.DoesNotContain("waypoints", requestOptions[1].Uri.Query);
        }

        [Fact]
        public void SplitDirectionsRequestOptions_With25Waypoints_ReturnsDirectionsRequestOptionsCollection()
        {
            // Arrange
            const string origin = "ORIGIN";
            const string destination = "DESTINATION";
            var waypoints = new List<Waypoint>();

            for (int i = 0; i < 25; i++)
            {
                waypoints.Add(new Waypoint($"WAYPOINT_{i + 1}"));
            }

            DirectionsRequestOptions options = new DirectionsRequestOptions(origin, destination).SetWaypoints(waypoints);

            // Act
            List<DirectionsRequestOptions> requestOptions = DirectionsService.SplitDirectionsRequestOptions(options).ToList();

            // Assert
            Assert.NotNull(requestOptions);
            Assert.Equal("ORIGIN", requestOptions[0].Origin);
            Assert.Equal("WAYPOINT_1", requestOptions[0].Waypoints.FirstOrDefault()?.Location);
            Assert.Equal("WAYPOINT_25", requestOptions[0].Waypoints.LastOrDefault()?.Location);
            Assert.Equal("DESTINATION", requestOptions[0].Destination);
        }
    }
}
