using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Geocoding;
using Google.Maps.WebServices.Tests.Data;
using Xunit;

namespace Google.Maps.WebServices.Tests.Core.Geocoding
{
    public class GeocodingRequestOptionsTests
    {
        private const string RequestEndpoint = "https://maps.googleapis.com/maps/api/geocode/json";
        private readonly GeocodingRequestOptions _options;

        public GeocodingRequestOptionsTests()
        {
            _options = new GeocodingRequestOptions();
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetValidAddress), MemberType = typeof(GeocodingTestData))]
        public void GeocodingRequestOptions_WithValidAddress_ContainsAddressQueryParameter(string address)
        {
            // Arrange
            var options = new GeocodingRequestOptions(address);

            // Act
            NameValueCollection query = HttpUtility.ParseQueryString(options.Uri.Query);

            // Assert
            Assert.Contains("address", options.Uri.Query);
            Assert.Equal(address, query.Get("address"));
            Assert.Equal($"{RequestEndpoint}?address={HttpUtility.UrlEncode(address)}", options.Uri.AbsoluteUri, true);
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetValidLocation), MemberType = typeof(GeocodingTestData))]
        public void GeocodingRequestOptions_WithValidLatLng_ContainsLatLngQueryParameter(LatLngLiteral location, string uriQueryValue)
        {
            // Arrange
            var options = new GeocodingRequestOptions(location);

            // Act
            NameValueCollection query = HttpUtility.ParseQueryString(options.Uri.Query);

            // Assert
            Assert.Contains("latlng", options.Uri.Query);
            Assert.Equal(uriQueryValue, query.Get("latlng"));
            Assert.Equal($"{RequestEndpoint}?latlng={HttpUtility.UrlEncode(uriQueryValue)}", options.Uri.AbsoluteUri);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void GeocodingRequestOptions_WithInvalidValues_ThrowsArgumentException(string address)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => new GeocodingRequestOptions(address));
        }

        [Fact]
        public void GeocodingRequestOptions_WithNull_ThrowsArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new GeocodingRequestOptions((LatLngLiteral)null));
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetValidBounds), MemberType = typeof(GeocodingTestData))]
        public void SetBounds_WithValidBounds_ContainsBoundsQueryParameter(Bounds bounds, string uriQueryValue)
        {
            // Act
            GeocodingRequestOptions request = _options.SetBounds(bounds);
            NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

            // Assert
            Assert.Contains("bounds", _options.Uri.Query);
            Assert.Equal(uriQueryValue, query.Get("bounds"));
            Assert.Equal($"{RequestEndpoint}?bounds={HttpUtility.UrlEncode(uriQueryValue)}", _options.Uri.AbsoluteUri);
            Assert.IsType<GeocodingRequestOptions>(request);
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetValidBoundsLatLngs), MemberType = typeof(GeocodingTestData))]
        public void SetBounds_WithValidLatLngs_ContainsBoundsQueryParameter(LatLngLiteral southWest, LatLngLiteral northEast, string uriQueryValue)
        {
            // Act
            GeocodingRequestOptions request = _options.SetBounds(southWest, northEast);
            NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

            // Assert
            Assert.Contains("bounds", _options.Uri.Query);
            Assert.Equal(uriQueryValue, query.Get("bounds"));
            Assert.Equal($"{RequestEndpoint}?bounds={HttpUtility.UrlEncode(uriQueryValue)}", _options.Uri.AbsoluteUri);
            Assert.IsType<GeocodingRequestOptions>(request);
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetInvalidBounds), MemberType = typeof(GeocodingTestData))]
        public void SetBounds_WithInvalidBoundsValues_ThrowsArgumentNullException(Bounds bounds)
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => _options.SetBounds(bounds));
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetInvalidLatLng), MemberType = typeof(GeocodingTestData))]
        public void SetBounds_WithInvalidLatLngValues_ThrowsArgumentNullException(LatLngLiteral southWest, LatLngLiteral northEast)
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => _options.SetBounds(southWest, northEast));
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetComponentFilters), MemberType = typeof(GeocodingTestData))]
        public void SetComponents_WithValidComponentFilters_ContainsComponentsQueryParameter(string uriQueryValue, params ComponentFilter[] componentFilters)
        {
            // Act
            GeocodingRequestOptions request = _options.SetComponents(componentFilters);
            NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

            // Assert
            Assert.Contains("components", _options.Uri.Query);
            Assert.Equal(uriQueryValue, query.Get("components"));
            Assert.Equal($"{RequestEndpoint}?components={HttpUtility.UrlEncode(uriQueryValue)}", _options.Uri.AbsoluteUri, true);
            Assert.IsType<GeocodingRequestOptions>(request);
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetComponentFilterCollection), MemberType = typeof(GeocodingTestData))]
        public void SetComponents_WithValidComponentFilterCollection_ContainsComponentsQueryParameter(IEnumerable<ComponentFilter> componentFilters, string uriQueryValue)
        {
            // Act
            GeocodingRequestOptions request = _options.SetComponents(componentFilters);
            NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

            // Assert
            Assert.Contains("components", _options.Uri.Query);
            Assert.Equal(uriQueryValue, query.Get("components"));
            Assert.Equal($"{RequestEndpoint}?components={HttpUtility.UrlEncode(uriQueryValue)}", _options.Uri.AbsoluteUri);
            Assert.IsType<GeocodingRequestOptions>(request);
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetComponentFilterTypeDictionary), MemberType = typeof(GeocodingTestData))]
        public void SetComponents_WithValidComponentFilterTypeDictionary_ContainsComponentsQueryParameter(IDictionary<ComponentFilterType, string> componentFilters, string uriQueryValue)
        {
            // Act
            GeocodingRequestOptions request = _options.SetComponents(componentFilters);
            NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

            // Assert
            Assert.Contains("components", _options.Uri.Query);
            Assert.Equal(uriQueryValue, query.Get("components"));
            Assert.Equal($"{RequestEndpoint}?components={HttpUtility.UrlEncode(uriQueryValue)}", _options.Uri.AbsoluteUri);
            Assert.IsType<GeocodingRequestOptions>(request);
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetInvalidComponentFilters), MemberType = typeof(GeocodingTestData))]
        public void SetComponents_WithInvalidComponentFilters_ThrowsArgumentException(params ComponentFilter[] componentFilters)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => _options.SetComponents(componentFilters));
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetInvalidComponentFilterCollection), MemberType = typeof(GeocodingTestData))]
        public void SetComponents_WithInvalidComponentFilterCollection_ThrowsArgumentException(IEnumerable<ComponentFilter> componentFilters)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => _options.SetComponents(componentFilters));
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetInvalidComponentFilterTypeDictionary), MemberType = typeof(GeocodingTestData))]
        public void SetComponents_WithInvalidComponentFilterTypeDictionary_ThrowsArgumentException(IDictionary<ComponentFilterType, string> componentFilters)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => _options.SetComponents(componentFilters));
        }

        [Fact]
        public void SetComponents_WithNull_ThrowsArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => _options.SetComponents((IEnumerable<ComponentFilter>)null));
            Assert.Throws<ArgumentNullException>(() => _options.SetComponents((IDictionary<ComponentFilterType, string>)null));
        }

        [Fact]
        public void SetComponents_WithNoValue_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => _options.SetComponents());
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetLocationTypes), MemberType = typeof(GeocodingTestData))]
        public void SetLocationType_WithLocationTypes_ContainsLocationTypeQueryParameter(string uriQueryValue, params LocationType[] locationTypes)
        {
            // Act
            GeocodingRequestOptions request = _options.SetLocationType(locationTypes);
            NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

            // Assert
            Assert.Contains("location_type", _options.Uri.Query);
            Assert.Equal(uriQueryValue, query.Get("location_type"));
            Assert.Equal($"{RequestEndpoint}?location_type={HttpUtility.UrlEncode(uriQueryValue)}", _options.Uri.AbsoluteUri);
            Assert.IsType<GeocodingRequestOptions>(request);
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetLocationTypeCollection), MemberType = typeof(GeocodingTestData))]
        public void SetLocationType_WithLocationTypeCollection_ContainsLocationTypeQueryParameter(IEnumerable<LocationType> locationTypes, string uriQueryValue)
        {
            // Act
            GeocodingRequestOptions request = _options.SetLocationType(locationTypes);
            NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

            // Assert
            Assert.Contains("location_type", _options.Uri.Query);
            Assert.Equal(uriQueryValue, query.Get("location_type"));
            Assert.Equal($"{RequestEndpoint}?location_type={HttpUtility.UrlEncode(uriQueryValue)}", _options.Uri.AbsoluteUri);
            Assert.IsType<GeocodingRequestOptions>(request);
        }

        [Fact]
        public void SetLocationType_WithInvalidValues_ThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => _options.SetLocationType(null));
            Assert.Throws<ArgumentException>(() => _options.SetLocationType(new List<LocationType>()));
        }

        [Fact]
        public void SetLocationType_WithNoValue_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => _options.SetLocationType());
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetRegion), MemberType = typeof(GeocodingTestData))]
        public void SetRegion_WithRegion_ContainsRegionQueryParameter(string region)
        {
            // Act
            GeocodingRequestOptions request = _options.SetRegion(region);
            NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

            // Assert
            Assert.Contains("region", _options.Uri.Query);
            Assert.Equal(region, query.Get("region"));
            Assert.Equal($"{RequestEndpoint}?region={HttpUtility.UrlEncode(region)}", _options.Uri.AbsoluteUri);
            Assert.IsType<GeocodingRequestOptions>(request);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void SetRegion_WithInvalidValues_ThrowsException(string region)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => _options.SetRegion(region));
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetAddressTypes), MemberType = typeof(GeocodingTestData))]
        public void SetResultType_WithAddressTypes_ContainsResultTypeQueryParameter(string uriQueryValue, params AddressType[] addressTypes)
        {
            // Act
            GeocodingRequestOptions request = _options.SetResultType(addressTypes);
            NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

            // Assert
            Assert.Contains("result_type", _options.Uri.Query);
            Assert.Equal(uriQueryValue, query.Get("result_type"));
            Assert.Equal($"{RequestEndpoint}?result_type={HttpUtility.UrlEncode(uriQueryValue)}", _options.Uri.AbsoluteUri);
            Assert.IsType<GeocodingRequestOptions>(request);
        }

        [Theory]
        [MemberData(nameof(GeocodingTestData.GetAddressTypeCollection), MemberType = typeof(GeocodingTestData))]
        public void SetResultType_WithAddressTypeCollection_ContainsResultTypeQueryParameter(IEnumerable<AddressType> addressTypes, string uriQueryValue)
        {
            // Act
            GeocodingRequestOptions request = _options.SetResultType(addressTypes);
            NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

            // Assert
            Assert.Contains("result_type", _options.Uri.Query);
            Assert.Equal(uriQueryValue, query.Get("result_type"));
            Assert.Equal($"{RequestEndpoint}?result_type={HttpUtility.UrlEncode(uriQueryValue)}", _options.Uri.AbsoluteUri);
            Assert.IsType<GeocodingRequestOptions>(request);
        }

        [Fact]
        public void SetResultType_WithInvalidValues_ThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => _options.SetResultType(null));
            Assert.Throws<ArgumentException>(() => _options.SetResultType(new List<AddressType>()));
        }

        [Fact]
        public void SetResultType_WithNoValue_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => _options.SetResultType());
        }

        [Fact]
        public void ValidateRequest_WithNoRequiredParameters_ThrowsInvalidOperationException()
        {
            // Assert
            Assert.Throws<InvalidOperationException>(() => _options.ValidateRequest());
        }

        [Fact]
        public void GeocodingRequestOption_WithMultipleQueryParameters_ContainsMultipleQueryParameters()
        {
            // Arrange
            Bounds bounds = new()
            {
                SouthWest = new LatLngLiteral(-90, -180),
                NorthEast = new LatLngLiteral(90, 180)
            };

            // Act
            GeocodingRequestOptions request = _options
                .SetBounds(bounds)
                .SetRegion("TEST_REGION");
            NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

            // Assert
            Assert.Contains("bounds", _options.Uri.Query);
            Assert.Equal("-90,-180|90,180", query.Get("bounds"));
            Assert.Contains("region", _options.Uri.Query);
            Assert.Equal("TEST_REGION", query.Get("region"));
            Assert.IsType<GeocodingRequestOptions>(request);
        }
    }
}
