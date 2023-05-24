using System;
using System.Collections.Specialized;
using System.Web;
using Google.Maps.WebServices.Directions;
using Google.Maps.WebServices.Exceptions;
using Google.Maps.WebServices.Tests.Data;
using Xunit;

namespace Google.Maps.WebServices.Tests.Core.Directions;

public class DirectionsRequestOptionsTests
{
    private const string RequestEndpoint = "https://maps.googleapis.com/maps/api/directions/json";
    private readonly DirectionsRequestOptions _options;

    public DirectionsRequestOptionsTests()
    {
        _options = new DirectionsRequestOptions();
    }

    [Theory]
    [MemberData(nameof(DirectionsTestData.GetDateTime), MemberType = typeof(DirectionsTestData))]
    public void SetArrivalTime_WithDateTime_ContainsArrivalTimeQueryParameter(DateTime arrivalTime, string expected)
    {
        // Act
        DirectionsRequestOptions request = _options.SetArrivalTime(arrivalTime);
        NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

        // Assert
        Assert.Contains("arrival_time", _options.Uri.Query);
        Assert.Equal(expected, query.Get("arrival_time"));
        Assert.Equal($"{RequestEndpoint}?arrival_time={HttpUtility.UrlEncode(expected)}", _options.Uri.AbsoluteUri);
        Assert.IsType<DirectionsRequestOptions>(request);
    }

    [Theory]
    [MemberData(nameof(DirectionsTestData.GetDateTimeOffset), MemberType = typeof(DirectionsTestData))]
    public void SetArrivalTime_WithDateTimeOffset_ContainsArrivalTimeQueryParameter(DateTimeOffset arrivalTime, string expected)
    {
        // Act
        DirectionsRequestOptions request = _options.SetArrivalTime(arrivalTime);
        NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

        // Assert
        Assert.Contains("arrival_time", _options.Uri.Query);
        Assert.Equal(expected, query.Get("arrival_time"));
        Assert.Equal($"{RequestEndpoint}?arrival_time={HttpUtility.UrlEncode(expected)}", _options.Uri.AbsoluteUri);
        Assert.IsType<DirectionsRequestOptions>(request);
    }

    [Theory]
    [InlineData(946731600, "946731600")]
    [InlineData(946645200, "946645200")]
    public void SetArrivalTime_WithEpochTimeStamp_ContainsArrivalTimeQueryParameter(long arrivalTime, string expected)
    {
        // Act
        DirectionsRequestOptions request = _options.SetArrivalTime(arrivalTime);
        NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

        // Assert
        Assert.Contains("arrival_time", _options.Uri.Query);
        Assert.Equal(expected, query.Get("arrival_time"));
        Assert.Equal($"{RequestEndpoint}?arrival_time={HttpUtility.UrlEncode(expected)}", _options.Uri.AbsoluteUri);
        Assert.IsType<DirectionsRequestOptions>(request);
    }

    [Fact]
    public void SetArrivalTime_WithUnspecifiedDateTimeKind_ThrowsArgumentException()
    {
        // Arrange
        DateTime arrivalTime = new(2000, 1, 1, 1, 0, 0, DateTimeKind.Unspecified);

        // Act
        void SetArrivalTime() => _options.SetArrivalTime(arrivalTime);

        // Assert
        Assert.Throws<ArgumentException>(SetArrivalTime);
    }

    [Theory]
    [MemberData(nameof(DirectionsTestData.GetDateTime), MemberType = typeof(DirectionsTestData))]
    public void SetDepartureTime_WithDateTime_ContainsDepartureTimeQueryParameter(DateTime departureTime, string expected)
    {
        // Act
        DirectionsRequestOptions request = _options.SetDepartureTime(departureTime);
        NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

        // Assert
        Assert.Contains("departure_time", _options.Uri.Query);
        Assert.Equal(expected, query.Get("departure_time"));
        Assert.Equal($"{RequestEndpoint}?departure_time={HttpUtility.UrlEncode(expected)}", _options.Uri.AbsoluteUri);
        Assert.IsType<DirectionsRequestOptions>(request);
    }

    [Theory]
    [MemberData(nameof(DirectionsTestData.GetDateTimeOffset), MemberType = typeof(DirectionsTestData))]
    public void SetDepartureTime_WithDateTimeOffset_ContainsDepartureTimeQueryParameter(DateTimeOffset departureTime, string expected)
    {
        // Act
        DirectionsRequestOptions request = _options.SetDepartureTime(departureTime);
        NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

        // Assert
        Assert.Contains("departure_time", _options.Uri.Query);
        Assert.Equal(expected, query.Get("departure_time"));
        Assert.Equal($"{RequestEndpoint}?departure_time={HttpUtility.UrlEncode(expected)}", _options.Uri.AbsoluteUri);
        Assert.IsType<DirectionsRequestOptions>(request);
    }

    [Theory]
    [InlineData(946731600, "946731600")]
    [InlineData(946645200, "946645200")]
    public void SetDepartureTime_WithEpochTimeStamp_ContainsDepartureTimeQueryParameter(long departureTime, string expected)
    {
        // Act
        DirectionsRequestOptions request = _options.SetDepartureTime(departureTime);
        NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

        // Assert
        Assert.Contains("departure_time", _options.Uri.Query);
        Assert.Equal(expected, query.Get("departure_time"));
        Assert.Equal($"{RequestEndpoint}?departure_time={HttpUtility.UrlEncode(expected)}", _options.Uri.AbsoluteUri);
        Assert.IsType<DirectionsRequestOptions>(request);
    }

    [Fact]
    public void SetDepartureTimeNow_ContainsDepartureTimeQueryParameter()
    {
        // Act
        const string expected = "now";
        DirectionsRequestOptions request = _options.SetDepartureTimeNow();
        NameValueCollection query = HttpUtility.ParseQueryString(_options.Uri.Query);

        // Assert
        Assert.Contains("departure_time", _options.Uri.Query);
        Assert.Equal(expected, query.Get("departure_time"));
        Assert.Equal($"{RequestEndpoint}?departure_time={HttpUtility.UrlEncode(expected)}", _options.Uri.AbsoluteUri);
        Assert.IsType<DirectionsRequestOptions>(request);
    }

    [Fact]
    public void SetDepartureTime_WithUnspecifiedDateTimeKind_ThrowsArgumentException()
    {
        // Arrange
        DateTime departureTime = new(2000, 1, 1, 1, 0, 0, DateTimeKind.Unspecified);

        // Act
        void SetDepartureTime() => _options.SetDepartureTime(departureTime);

        // Assert
        Assert.Throws<ArgumentException>(SetDepartureTime);
    }

    [Fact]
    public void BuildUri_WithDirectionsRequestOptions_ReturnsUri()
    {
        // Arrange
        const string expected = "origin=ORIGIN_TEST&destination=DESTINATION_TEST";

        // Act
        Uri request = _options.SetOrigin("ORIGIN_TEST").SetDestination("DESTINATION_TEST").BuildUri();

        // Assert
        Assert.IsType<Uri>(request);
        Assert.Equal(expected, request.Query.Remove(0, 1));
    }

    [Fact]
    public void BuildUri_WithEmptyDirectionsRequestOptions_ThrowsRequestUriValidationException()
    {
        // Act
        void BuildUri() => _options.BuildUri();

        // Assert
        Assert.Throws<RequestUriValidationException>(BuildUri);
    }

    [Fact]
    public void BuildUri_WithDirectionsRequestOptionsWithoutDestination_ThrowsRequestUriValidationException()
    {
        // Act
        void BuildUri() => _options.SetOrigin("ORIGIN_TEST").BuildUri();

        // Assert
        Assert.Throws<RequestUriValidationException>(BuildUri);
    }

    [Fact]
    public void BuildUri_WithDirectionsRequestOptionsWithoutOrigin_ThrowsRequestUriValidationException()
    {
        // Act
        void BuildUri() => _options.SetDestination("DESTINATION_TEST").BuildUri();

        // Assert
        Assert.Throws<RequestUriValidationException>(BuildUri);
    }
}