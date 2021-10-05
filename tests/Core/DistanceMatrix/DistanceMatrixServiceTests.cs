using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.DistanceMatrix;
using Google.Maps.WebServices.Tests.TestHelpers;
using Xunit;

namespace Google.Maps.WebServices.Tests.Core.DistanceMatrix
{
    public class DistanceMatrixServiceTests
    {
        private readonly HttpClientFixture _httpClientFixture;

        public DistanceMatrixServiceTests()
        {
            _httpClientFixture = new HttpClientFixture();
        }

        [Fact]
        public async Task GetDistanceMatrixAsync_WithDistanceMatrixResponseJson_HasValidDistanceMatrixAddresses()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("DistanceMatrixResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);
            List<string> origins = GetOrigins();
            List<string> destinations = GetDestinations();

            // Act
            DistanceMatrixResult response = await googleMapsClient.GetDistanceMatrixAsync(origins, destinations);
            List<string> originAddresses = response.OriginAddresses.ToList();
            List<string> destinationAddresses = response.DestinationAddresses.ToList();

            // Assert
            Assert.NotNull(originAddresses);
            Assert.NotNull(destinationAddresses);
            Assert.Equal(8, originAddresses.Count);
            Assert.Equal(5, destinationAddresses.Count);
            Assert.Equal("Perth WA, Australia", originAddresses[0]);
            Assert.Equal("Sydney NSW, Australia", originAddresses[1]);
            Assert.Equal("Melbourne VIC, Australia", originAddresses[2]);
            Assert.Equal("Adelaide SA, Australia", originAddresses[3]);
            Assert.Equal("Brisbane QLD, Australia", originAddresses[4]);
            Assert.Equal("Darwin NT, Australia", originAddresses[5]);
            Assert.Equal("Hobart TAS 7000, Australia", originAddresses[6]);
            Assert.Equal("Canberra ACT 2601, Australia", originAddresses[7]);
            Assert.Equal("Uluru, Petermann NT 0872, Australia", destinationAddresses[0]);
            Assert.Equal("Kakadu NT 0822, Australia", destinationAddresses[1]);
            Assert.Equal("Blue Mountains, New South Wales, Australia", destinationAddresses[2]);
            Assert.Equal("Purnululu National Park, Western Australia 6770, Australia", destinationAddresses[3]);
            Assert.Equal("Pinnacles Drive, Cervantes WA 6511, Australia", destinationAddresses[4]);
        }

        [Fact]
        public async Task GetDistanceMatrixAsync_WithDistanceMatrixResponseJson_HasValidDistanceMatrixElements()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("DistanceMatrixResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);
            List<string> origins = GetOrigins();
            List<string> destinations = GetDestinations();

            // Act
            DistanceMatrixResult response = await googleMapsClient.GetDistanceMatrixAsync(origins, destinations);
            var rows = response.Rows.ToList();
            var elements = rows[0].Elements.ToList();

            // Assert
            Assert.Equal(8, rows.Count);
            Assert.Equal(5, elements.Count);
            Assert.Equal(DistanceMatrixElementStatus.Ok, elements[0].Status);
            Assert.NotNull(elements[0].Distance);
            Assert.NotNull(elements[0].Duration);
            Assert.Equal(3669839, elements[0].Distance.Meters);
            Assert.Equal("3,670 km", elements[0].Distance.DisplayValue);
            Assert.Equal(137846, elements[0].Duration.Seconds);
            Assert.Equal("1 day 14 hours", elements[0].Duration.DisplayValue);
        }

        [Fact]
        public async Task GetDistanceMatrixAsync_WithDistanceMatrixResponseJson_HasValidDistanceMatrixResponse()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("DistanceMatrixResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);
            List<string> origins = GetOrigins();
            List<string> destinations = GetDestinations();

            // Act
            GoogleMapsResponse<DistanceMatrixResult> response = await googleMapsClient.GetDistanceMatrixAsync(origins, destinations);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccessful);
            Assert.Equal(ApiResponseStatus.Ok, response.ResponseStatus);
            Assert.Null(response.ErrorMessage);
        }

        [Fact]
        public async Task GetDistanceMatrixAsync_WithDistanceMatrixResponseJson_HasValidDistanceMatrixResult()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("DistanceMatrixResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);
            List<string> origins = GetOrigins();
            List<string> destinations = GetDestinations();

            // Act
            DistanceMatrixResult response = await googleMapsClient.GetDistanceMatrixAsync(origins, destinations);

            // Assert
            Assert.NotNull(response.OriginAddresses);
            Assert.NotNull(response.DestinationAddresses);
            Assert.NotNull(response.Rows);
        }

        private static List<string> GetDestinations()
        {
            return new List<string>
            {
                "Uluru, Australia",
                "Kakadu, Australia",
                "Blue Mountains, Australia",
                "Bungle Bungles, Australia",
                "The Pinnacles, Australia"
            };
        }

        private static List<string> GetOrigins()
        {
            return new List<string>
            {
                "Perth, Australia",
                "Sydney, Australia",
                "Melbourne, Australia",
                "Adelaide, Australia",
                "Brisbane, Australia",
                "Darwin, Australia",
                "Hobart, Australia",
                "Canberra, Australia"
            };
        }
    }
}
