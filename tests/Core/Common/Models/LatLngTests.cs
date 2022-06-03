using System.Globalization;
using System.Threading;
using Google.Maps.WebServices.Common;
using Xunit;

namespace Google.Maps.WebServices.Tests.Core.Common.Models
{
    public class LatLngTests
    {
        [Fact]
        public void Equals_WithLatLng_ReturnTrue()
        {
            // Arrange
            var a = new LatLngLiteral(10.0, 10);
            var b = new LatLngLiteral(10, 10);

            // Assert
            Assert.Equal(a, b);
        }

        [Theory]
        [InlineData("en-NZ")]
        [InlineData("en-GB")]
        [InlineData("en-US")]
        [InlineData("de-DE")]
        [InlineData("ru-RU")]
        [InlineData("zh-CN")]
        public void ToUriValue_WithLatLng_ReturnsInvariantCultureString(string culture)
        {
            // Arrange
            var latLng = new LatLngLiteral(12.3456, 0.1234);

            // Act
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            // Assert
            Assert.Equal("12.3456,0.1234", latLng.ToUriValue());
        }
    }
}
