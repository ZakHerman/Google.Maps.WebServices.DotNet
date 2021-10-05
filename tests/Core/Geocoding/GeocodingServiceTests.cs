using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Geocoding;
using Google.Maps.WebServices.Tests.TestHelpers;
using Xunit;

namespace Google.Maps.WebServices.Tests.Core.Geocoding
{
    public class GeocodingServiceTests
    {
        private readonly HttpClientFixture _httpClientFixture;

        public GeocodingServiceTests()
        {
            _httpClientFixture = new HttpClientFixture();
        }

        [Fact]
        public async Task GeocodeAsync_WithGeocodingResponseJson_HasValidAddressComponents()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("GeocodingResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);

            // Act
            GoogleMapsResponse<IEnumerable<GeocodingResult>> response = await googleMapsClient.GeocodeAsync("ADDRESS_TEST");
            List<AddressComponent> addressComponents = response.Result.First().AddressComponents;

            // Assert
            Assert.NotNull(addressComponents);
            Assert.Equal(7, addressComponents.Count);
            Assert.Equal("1600", addressComponents[0].LongName);
            Assert.Equal("1600", addressComponents[0].ShortName);
            Assert.Contains(AddressComponentType.StreetNumber, addressComponents[0].AddressComponentTypes);
            Assert.Single(addressComponents[0].AddressComponentTypes);
            Assert.Equal("Amphitheatre Parkway", addressComponents[1].LongName);
            Assert.Equal("Amphitheatre Pkwy", addressComponents[1].ShortName);
        }

        [Fact]
        public async Task GeocodeAsync_WithGeocodingResponseJson_HasValidGeocodingResponse()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("GeocodingResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);

            // Act
            GoogleMapsResponse<IEnumerable<GeocodingResult>> response = await googleMapsClient.GeocodeAsync("ADDRESS_TEST");

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccessful);
            Assert.Equal(ApiResponseStatus.Ok, response.ResponseStatus);
            Assert.Null(response.ErrorMessage);
        }

        [Fact]
        public async Task GeocodeAsync_WithGeocodingResponseJson_HasValidGeocodingResult()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("GeocodingResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);

            // Act
            GoogleMapsResponse<IEnumerable<GeocodingResult>> response = await googleMapsClient.GeocodeAsync("ADDRESS_TEST");
            GeocodingResult geocodingResult = response.Result.First();

            // Assert
            Assert.NotNull(geocodingResult);
            Assert.NotNull(geocodingResult.PlusCode);
            Assert.Equal("1600 Amphitheatre Pkwy, Mountain View, CA 94043, USA", geocodingResult.FormattedAddress);
            Assert.Equal("ChIJb3E-eva5j4ARfZQR8h3UgQk", geocodingResult.PlaceId);
            Assert.Equal("CWC8+FP Mountain View, CA, USA", geocodingResult.PlusCode.CompoundCode);
            Assert.Equal("849VCWC8+FP", geocodingResult.PlusCode.GlobalCode);
            Assert.Single(geocodingResult.AddressTypes);
            Assert.Contains(AddressType.StreetAddress, geocodingResult.AddressTypes);
        }

        [Fact]
        public async Task GeocodeAsync_WithGeocodingResponseJson_HasValidGeometry()
        {
            // Arrange
            HttpClient httpClient = await _httpClientFixture.CreateHttpClientAsync("GeocodingResponse.json");
            var googleMapsClient = new GoogleMapsServiceClient("FAKE_KEY", httpClient);

            // Act
            GoogleMapsResponse<IEnumerable<GeocodingResult>> response = await googleMapsClient.GeocodeAsync("ADDRESS_TEST");
            Geometry geometry = response.Result.First().Geometry;

            // Assert
            Assert.NotNull(geometry);
            Assert.NotNull(geometry.Location);
            Assert.NotNull(geometry.ViewPort);
            Assert.NotNull(geometry.ViewPort.NorthEast);
            Assert.NotNull(geometry.ViewPort.SouthWest);
            Assert.Equal(37.4219891, geometry.Location.Latitude);
            Assert.Equal(-122.0840944, geometry.Location.Longitude);
            Assert.Equal(LocationType.Rooftop, geometry.LocationType);
            Assert.Equal(37.4233380802915, geometry.ViewPort.NorthEast.Latitude);
            Assert.Equal(-122.0827454197085, geometry.ViewPort.NorthEast.Longitude);
            Assert.Equal(37.4206401197085, geometry.ViewPort.SouthWest.Latitude);
            Assert.Equal(-122.0854433802915, geometry.ViewPort.SouthWest.Longitude);
        }
    }
}
