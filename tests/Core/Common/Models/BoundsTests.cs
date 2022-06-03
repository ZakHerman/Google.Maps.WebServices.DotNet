using System;
using Google.Maps.WebServices.Common;
using Xunit;

namespace Google.Maps.WebServices.Tests.Core.Common.Models
{
    public class BoundsTests
    {
        [Fact]
        public void Merge_WithNoValidBounds_ThrowsArgumentException()
        {
            // Arrange
            Bounds emptyBoundsOne = new();
            Bounds emptyBoundsTwo = new();
            Bounds missingSouthWestBounds = new() { NorthEast = new LatLngLiteral() };
            Bounds missingNorthEastBounds = new() { SouthWest = new LatLngLiteral() };

            // Assert
            Assert.Throws<ArgumentException>(() => Bounds.Merge(null, null));
            Assert.Throws<ArgumentException>(() => Bounds.Merge(emptyBoundsOne, emptyBoundsTwo));
            Assert.Throws<ArgumentException>(() => Bounds.Merge(missingSouthWestBounds, missingSouthWestBounds));
            Assert.Throws<ArgumentException>(() => Bounds.Merge(missingNorthEastBounds, missingNorthEastBounds));
        }

        [Fact]
        public void Merge_WithOneValidBounds_ReturnsCombinedBounds()
        {
            // Arrange
            Bounds boundsOne = GetBoundsOne();
            Bounds boundsTwo = GetBoundsTwo();
            Bounds missingSouthWestBounds = new() { NorthEast = new LatLngLiteral() };
            Bounds missingNorthEastBounds = new() { SouthWest = new LatLngLiteral() };

            // Act
            Bounds combinedBounds = Bounds.Merge(new Bounds(), boundsTwo);
            Bounds combinedBoundsTwo = Bounds.Merge(boundsOne, null);
            Bounds combinedBoundsThree = Bounds.Merge(missingSouthWestBounds, missingNorthEastBounds);
            Bounds combinedBoundsFour = Bounds.Merge(boundsTwo, null);

            // Assert
            Assert.Equal(-51, combinedBounds.NorthEast.Latitude);
            Assert.Equal(101, combinedBounds.NorthEast.Longitude);
            Assert.Equal(0, combinedBounds.SouthWest.Latitude);
            Assert.Equal(180, combinedBounds.SouthWest.Longitude);
            Assert.Equal(-50, combinedBoundsTwo.NorthEast.Latitude);
            Assert.Equal(100, combinedBoundsTwo.NorthEast.Longitude);
            Assert.Equal(1, combinedBoundsTwo.SouthWest.Latitude);
            Assert.Equal(179, combinedBoundsTwo.SouthWest.Longitude);
            Assert.NotNull(combinedBoundsThree);
            Assert.StrictEqual(combinedBoundsThree.SouthWest, combinedBoundsThree.NorthEast);
            Assert.Equal(-51, combinedBoundsFour.NorthEast.Latitude);
            Assert.Equal(101, combinedBoundsFour.NorthEast.Longitude);
            Assert.Equal(0, combinedBoundsFour.SouthWest.Latitude);
            Assert.Equal(180, combinedBoundsFour.SouthWest.Longitude);
        }

        [Fact]
        public void Merge_WithTwoValidBounds_ReturnsCombinedBounds()
        {
            // Arrange
            Bounds boundsOne = GetBoundsOne();
            Bounds boundsTwo = GetBoundsTwo();

            // Act
            Bounds combinedBounds = Bounds.Merge(boundsOne, boundsTwo);

            // Assert
            Assert.Equal(-50, combinedBounds.NorthEast.Latitude);
            Assert.Equal(101, combinedBounds.NorthEast.Longitude);
            Assert.Equal(0, combinedBounds.SouthWest.Latitude);
            Assert.Equal(179, combinedBounds.SouthWest.Longitude);
        }

        private static Bounds GetBoundsOne()
        {
            return new Bounds
            {
                NorthEast = new LatLngLiteral
                {
                    Latitude = -50,
                    Longitude = 100
                },
                SouthWest = new LatLngLiteral
                {
                    Latitude = 1,
                    Longitude = 179
                }
            };
        }

        private static Bounds GetBoundsTwo()
        {
            return new Bounds
            {
                NorthEast = new LatLngLiteral
                {
                    Latitude = -51,
                    Longitude = 101
                },
                SouthWest = new LatLngLiteral
                {
                    Latitude = 0,
                    Longitude = 180
                }
            };
        }
    }
}
