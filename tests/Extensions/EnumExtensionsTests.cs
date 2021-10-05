using System;
using System.Runtime.Serialization;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Extensions;
using Google.Maps.WebServices.Geocoding;
using Xunit;

namespace Google.Maps.WebServices.Tests.Extensions
{
    public class EnumExtensionsTests
    {
        private enum TestEnum
        {
            [EnumMember(Value = "In Progress")]
            InProgress,

            PartialSuccess
        }

        [Theory]
        [InlineData(AddressComponentType.StreetAddress, "street_address")]
        [InlineData(AddressType.RvPark, "rv_park")]
        [InlineData(ApiResponseStatus.Ok, "OK")]
        [InlineData(ApiResponseStatus.MaxRouteLengthExceeded, "MAX_ROUTE_LENGTH_EXCEEDED")]
        [InlineData(ApiResponseStatus.UserRateLimitExceeded, "userRateLimitExceeded")]
        [InlineData(ComponentFilterType.PostalCode, "postal_code")]
        [InlineData(GeocodedWaypointStatus.ZeroResults, "ZERO_RESULTS")]
        [InlineData(Language.SpanishLatinAmerica, "es-419")]
        [InlineData(TravelMode.Driving, "DRIVING")]
        [InlineData(TestEnum.InProgress, "In Progress")]
        [InlineData(TestEnum.PartialSuccess, "PartialSuccess")]
        public void ToUriValue_WithValidEnum_ReturnsString(Enum @enum, string enumMemberValue)
        {
            // Act
            string result = @enum.ToUriValue();

            // Assert
            Assert.Equal(enumMemberValue, result);
        }
    }
}
