namespace Google.Maps.WebServices.Common;

/// <summary>
/// An interface to be implemented by a class that handle a Google Maps Web Service response.
/// </summary>
/// <typeparam name="T">The Google Maps Web Service result.</typeparam>
public interface IResponse<out T>
{
    /// <summary>
    /// When the top-level status code is other than <see cref="ApiResponseStatus.Ok" />, this
    /// field contains more detailed information about the reasons behind the given status code.
    /// </summary>
    string ErrorMessage { get; }

    /// <summary>
    /// Gets a value that indicates whether the response was successful.
    /// </summary>
    bool IsSuccessful { get; }

    /// <summary>
    /// The status of the Google Maps Web Service request.
    /// </summary>
    ApiResponseStatus ResponseStatus { get; }

    /// <summary>
    /// The result of the Google Maps Web Service request.
    /// </summary>
    T Result { get; }
}