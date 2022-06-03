using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Roads;
using Google.Maps.WebServices.Tests.TestHelpers;
using Xunit;

namespace Google.Maps.WebServices.Tests.Core.Roads
{
    public class RoadsServiceTests
    {
        private readonly HttpClientFixture _httpClientFixture;

        public RoadsServiceTests()
        {
            _httpClientFixture = new HttpClientFixture();
        }

        [Fact]
        public async Task NearestRoadsAsync_WithNearestRoadsResponseJson_HasValidResponse()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("NearestRoadsResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);
            List<LatLngLiteral> points = GetPath();

            // Act
            GoogleMapsResponse<IEnumerable<SnappedPointResult>> response = await googleMapsClient.NearestRoadsAsync(points);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccessful);
            Assert.Equal(ApiResponseStatus.Ok, response.ResponseStatus);
            Assert.Null(response.ErrorMessage);
        }

        [Fact]
        public async Task NearestRoadsAsync_WithNearestRoadsResponseJson_HasValidResult()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("NearestRoadsResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);
            List<LatLngLiteral> points = GetPath();

            // Act
            GoogleMapsResponse<IEnumerable<SnappedPointResult>> response = await googleMapsClient.NearestRoadsAsync(points);
            List<SnappedPointResult> results = response.Result.ToList();

            // Assert
            Assert.NotNull(results);
            Assert.Equal(3, results.Count);
            Assert.True(results.All(snappedPointResult => snappedPointResult.OriginalIndex != null));
            Assert.Equal(60.170877918672588, results[0].Location.Latitude);
            Assert.Equal(24.942699821922421, results[0].Location.Longitude);
            Assert.Equal(0, results[0].OriginalIndex);
            Assert.Equal("ChIJNX9BrM0LkkYRIM-cQg265e8", results[0].PlaceId);
        }

        [Fact]
        public async Task SnapToRoadsAsync_WithSnapToRoadsResponseJson_HasValidResponse()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("SnapToRoadsResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);
            List<LatLngLiteral> path = GetPath();

            // Act
            GoogleMapsResponse<IEnumerable<SnappedPointResult>> response = await googleMapsClient.SnapToRoadsAsync(path);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccessful);
            Assert.Equal(ApiResponseStatus.Ok, response.ResponseStatus);
            Assert.Null(response.ErrorMessage);
        }

        [Fact]
        public async Task SnapToRoadsAsync_WithSnapToRoadsResponseJson_HasValidResult()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("SnapToRoadsResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);
            List<LatLngLiteral> path = GetPath();

            // Act
            GoogleMapsResponse<IEnumerable<SnappedPointResult>> response = await googleMapsClient.SnapToRoadsAsync(path);
            List<SnappedPointResult> results = response.Result.ToList();

            // Assert
            Assert.NotNull(results);
            Assert.Equal(14, results.Count);
            Assert.Equal(-35.2784167, results[0].Location.Latitude);
            Assert.Equal(149.1294692, results[0].Location.Longitude);
            Assert.Equal(0, results[0].OriginalIndex);
            Assert.Equal("ChIJoR7CemhNFmsRQB9QbW7qABM", results[0].PlaceId);
        }

        private static List<LatLngLiteral> GetPath()
        {
            return new List<LatLngLiteral>
            {
                new(-35.27801, 149.12958),
                new(-35.28032, 149.12907),
                new(-35.28099, 149.12929),
                new(-35.28144, 149.12984),
                new(-35.28194, 149.13003),
                new(-35.28282, 149.12956),
                new(-35.28302, 149.12881),
                new(-35.28473, 149.12836)
            };
        }
    }
}
