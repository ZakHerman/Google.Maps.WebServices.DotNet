using System.Runtime.Serialization;

namespace Google.Maps.WebServices.Common;

/// <summary>
/// The status result of the API response.
/// </summary>
/// <remarks>
/// See <a
/// href="https://developers.google.com/maps/documentation/directions/get-directions#StatusCodes">Status
/// Codes</a> for more detail.
/// </remarks>
public enum ApiResponseStatus
{
    /// <summary>
    /// Indicates that the request could not be processed due to a server error.
    /// </summary>
    /// <remarks>The request may succeed if you try again.</remarks>
    [EnumMember(Value = "UNKNOWN_ERROR")]
    Unknown,

    /// <summary>
    /// Indicates the service request was successful.
    /// </summary>
    [EnumMember(Value = "OK")]
    Ok,

    /// <summary>
    /// The request was valid, but no results were returned.
    /// </summary>
    /// <remarks>
    /// Directions API: Indicates at least one of the locations specified in the request's
    /// origin, destination, or waypoints could not be geocoded.
    /// </remarks>
    [EnumMember(Value = "NOT_FOUND")]
    NotFound,

    /// <summary>
    /// Indicates no route could be found between the origin and destination.
    /// </summary>
    [EnumMember(Value = "ZERO_RESULTS")]
    ZeroResults,

    /// <summary>
    /// Indicates that too many waypoints were provided in the request.
    /// </summary>
    /// <remarks>The maximum allowed number of waypoints is 25, plus the origin and destination.</remarks>
    [EnumMember(Value = "MAX_WAYPOINTS_EXCEEDED")]
    MaxWaypointsExceeded,

    /// <summary>
    /// Indicates the requested route is too long and cannot be processed.
    /// </summary>
    /// <remarks>
    /// This error occurs when more complex directions are returned. Try reducing the number of
    /// waypoints, turns, or instructions.
    /// </remarks>
    [EnumMember(Value = "MAX_ROUTE_LENGTH_EXCEEDED")]
    MaxRouteLengthExceeded,

    /// <summary>
    /// Indicates that the provided request was invalid.
    /// </summary>
    /// <remarks>Common causes of this status include an invalid parameter or parameter value.</remarks>
    [EnumMember(Value = "INVALID_REQUEST")]
    InvalidRequest,

    /// <summary>
    /// Indicates any of the following:
    /// <list type="bullet">
    /// <item>
    /// <description>The API key is missing or invalid.</description>
    /// </item>
    /// <item>
    /// <description>Billing has not been enabled on your account.</description>
    /// </item>
    /// <item>
    /// <description>A self-imposed usage cap has been exceeded.</description>
    /// </item>
    /// <item>
    /// <description>
    /// The provided method of payment is no longer valid (for example, a credit card has expired).
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.google.com/maps/faq#over-limit-key-error">Maps
    /// FAQ</a> to learn how to fix this.
    /// </remarks>
    [EnumMember(Value = "OVER_DAILY_LIMIT")]
    OverDailyLimit,

    /// <summary>
    /// You have exceeded your daily limit.
    /// </summary>
    /// <remarks>
    /// See <a
    /// href="https://developers.google.com/maps/documentation/geolocation/usage-and-billing#other-usage-limits">Geolocation</a>
    /// for more detail.
    /// </remarks>
    [EnumMember(Value = "dailyLimitExceeded")]
    DailyLimitExceeded,

    /// <summary>
    /// Indicates the service has received too many requests from your application within the
    /// allowed time period.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.google.com/maps/faq#over-limit-key-error">Maps
    /// FAQ</a> to learn how to fix this.
    /// </remarks>
    [EnumMember(Value = "OVER_QUERY_LIMIT")]
    OverQueryLimit,

    /// <summary>
    /// Indicates that the service denied use of the service by your application.
    /// </summary>
    [EnumMember(Value = "REQUEST_DENIED")]
    RequestDenied,

    /// <summary>
    /// Indicates that the product of origins and destinations exceeds the per-query limit.
    /// </summary>
    [EnumMember(Value = "MAX_ELEMENTS_EXCEEDED")]
    MaxElementsExceeded,

    /// <summary>
    /// Indicates that the number of origins or destinations exceeds the per-query limit.
    /// </summary>
    [EnumMember(Value = "MAX_DIMENSIONS_EXCEEDED")]
    MaxDimensionsExceeded,

    /// <summary>
    /// Indicates that the API call was not configured for the supplied credentials and
    /// environmental conditions.
    /// </summary>
    [EnumMember(Value = "ACCESS_NOT_CONFIGURED")]
    AccessNotConfigured,

    /// <summary>
    /// Indicates that the API received a malformed request.
    /// </summary>
    [EnumMember(Value = "INVALID_ARGUMENT")]
    InvalidArgument,

    /// <summary>
    /// Indicates that the requesting account has exceeded its short-term quota.
    /// </summary>
    /// <remarks>
    /// This limit is typically set as requests per day, requests per 100 seconds, and requests
    /// per 100 seconds per user.
    /// </remarks>
    [EnumMember(Value = "RESOURCE_EXHAUSTED")]
    ResourceExhausted,

    /// <summary>
    /// Indicates that the request was denied for one or more of the following reasons:
    /// <list type="bullet">
    /// <item>
    /// <description>The API key is missing or invalid.</description>
    /// </item>
    /// <item>
    /// <description>Billing has not been enabled on your account.</description>
    /// </item>
    /// <item>
    /// <description>A self-imposed usage cap has been exceeded.</description>
    /// </item>
    /// <item>
    /// <description>
    /// The provided method of payment is no longer valid (for example, a credit card has expired).
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    [EnumMember(Value = "PERMISSION_DENIED")]
    PermissionDenied,

    /// <summary>
    /// Indicates that the API key is not valid for the Geolocation API.
    /// </summary>
    /// <remarks>
    /// Ensure that you've included the entire key, and that you've either purchased the API or
    /// have enabled billing and activated the API to obtain the free quota.
    /// </remarks>
    [EnumMember(Value = "keyInvalid")]
    KeyInvalid,

    /// <summary>
    /// Indicates that the service exceeded the request limit that is configured in the Google
    /// Cloud Console.
    /// </summary>
    /// <remarks>
    /// This limit is typically set as requests per day, requests per 100 seconds, and requests
    /// per 100 seconds per user.
    /// </remarks>
    [EnumMember(Value = "userRateLimitExceeded")]
    UserRateLimitExceeded,

    /// <summary>
    /// Indicates that the request was valid, but no results were returned.
    /// </summary>
    [EnumMember(Value = "notFound")]
    ResultsNotFound,

    /// <summary>
    /// Indicates that the request body is not valid JSON.
    /// </summary>
    [EnumMember(Value = "parseError")]
    ParseError,

    /// <summary>
    /// Indicates that the API received a malformed request.
    /// </summary>
    [EnumMember(Value = "invalid")]
    Invalid
}