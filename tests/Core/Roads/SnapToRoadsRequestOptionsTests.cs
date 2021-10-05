using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Roads;
using Xunit;

namespace Google.Maps.WebServices.Tests.Core.Roads
{
    public class SnapToRoadsRequestOptionsTests
    {
        [Fact]
        public void InterpolatePath_WithSnapToRoadsRequestOptions_ContainsInterpolateQuery()
        {
            // Arrange
            var options = new SnapToRoadsRequestOptions(GetPath());

            // Act
            options.InterpolatePath();
            NameValueCollection query = HttpUtility.ParseQueryString(options.Uri.Query);

            // Assert
            Assert.Equal("-35.27801,149.12958|-35.28032,149.12907", query.Get("path"));
            Assert.Equal("True", query.Get("interpolate"));
            Assert.Equal("https://roads.googleapis.com/v1/snapToRoads?path=-35.27801%2c149.12958%7c-35.28032%2c149.12907&interpolate=True", options.Uri.AbsoluteUri);
        }

        [Fact]
        public void SnapToRoadsRequestOptions_WithNoOptionalQueryParameters_ReturnsCorrectUri()
        {
            // Arrange
            var options = new SnapToRoadsRequestOptions();

            // Act
            options.SetPath(GetPath());
            NameValueCollection query = HttpUtility.ParseQueryString(options.Uri.Query);

            // Assert
            Assert.Equal("-35.27801,149.12958|-35.28032,149.12907", query.Get("path"));
            Assert.Equal("https://roads.googleapis.com/v1/snapToRoads?path=-35.27801%2c149.12958%7c-35.28032%2c149.12907", options.Uri.AbsoluteUri);
        }

        private static IEnumerable<LatLng> GetPath()
        {
            return new List<LatLng>
            {
                new LatLng(-35.27801, 149.12958),
                new LatLng(-35.28032, 149.12907)
            };
        }
    }
}
