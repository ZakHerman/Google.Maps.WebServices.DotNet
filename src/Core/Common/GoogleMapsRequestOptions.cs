using System;
using System.Collections.Generic;
using System.Linq;
using Google.Maps.WebServices.Exceptions;
using Google.Maps.WebServices.Extensions;

namespace Google.Maps.WebServices.Common;

/// <summary>
/// A Google Maps Web Service request builder class.
/// </summary>
public abstract class GoogleMapsRequestOptions<T> where T : class
{
    private const string GoogleMapsUrlHostName = "https://maps.googleapis.com";
    private const int RequestUrlCharacterLimit = 8192;
    private readonly UriBuilder _uriBuilder;

    private protected IDictionary<string, string> ValidationFailures { get; } = new Dictionary<string, string>();

    /// <summary>
    /// Constructs an instance of the <see cref="GoogleMapsRequestOptions{T}" /> class.
    /// </summary>
    /// <param name="uri">The <see cref="System.Uri"/>.</param>
    protected GoogleMapsRequestOptions(Uri uri)
    {
        _uriBuilder = new UriBuilder(uri);
    }

    /// <summary>
    /// Constructs an instance of the <see cref="GoogleMapsRequestOptions{T}" /> class.
    /// </summary>
    /// <param name="urlPath">The url path for the selected Google Maps Web Service.</param>
    protected GoogleMapsRequestOptions(string urlPath) : this(new Uri(GoogleMapsUrlHostName + urlPath))
    { }

    /// <summary>
    /// Constructs an instance of the <see cref="GoogleMapsRequestOptions{T}" /> class.
    /// </summary>
    /// <param name="urlHostName">
    /// The url host name used to override the default <see cref="GoogleMapsUrlHostName" />.
    /// </param>
    /// <param name="urlPath">The url path for the selected Google Maps Web Service.</param>
    protected GoogleMapsRequestOptions(string urlHostName, string urlPath) : this(new Uri(urlHostName + urlPath))
    { }

    /// <summary>
    /// The request URI.
    /// </summary>
    internal Uri Uri => _uriBuilder.Uri;

    /// <summary>
    /// Gets the request URI.
    /// </summary>
    /// <returns>A <see cref="System.Uri" /> of the request.</returns>
    public Uri BuildUri()
    {
        ValidateRequest();

        return _uriBuilder.Uri;
    }

    /// <summary>
    /// Sets a custom query parameter.
    /// </summary>
    /// <param name="key">The key of the custom parameter.</param>
    /// <param name="value">The value of the custom parameter.</param>
    /// <returns>Returns this instance for call chaining.</returns>
    public T SetCustomParameter(string key, string value)
    {
        return SetQueryParameter(key, value);
    }

    /// <summary>
    /// Sets the language in which to return results.
    /// </summary>
    /// <remarks>
    /// See <see href="https://developers.google.com/maps/faq#languagesupport">Supported
    /// Languages</see> for more detail.
    /// </remarks>
    /// <param name="language">The language code, e.g. "en-AU" or "es".</param>
    /// <returns>Returns this instance for call chaining.</returns>
    public T SetLanguage(Language language)
    {
        return SetQueryParameter("language", language.ToUriValue());
    }

    /// <summary>
    /// Sets the API key which is used to authenticate requests to Google Maps Web Services.
    /// </summary>
    /// <param name="apiKey">The API key used to authenticate requests.</param>
    /// <returns>Returns this instance for call chaining.</returns>
    internal T SetAuthentication(string apiKey)
    {
        return SetQueryParameter("key", apiKey);
    }

    /// <summary>
    /// Validates that the request query is structured correctly according to the provided
    /// Google Maps Web Service documentation.
    /// </summary>
    internal virtual void ValidateRequest()
    {
        if (Uri.AbsoluteUri.Length >= RequestUrlCharacterLimit)
            ValidationFailures.Add("URL length", $"URL cannot contain more than {RequestUrlCharacterLimit} characters.");

        if (ValidationFailures.Any())
            throw new RequestUriValidationException(ValidationFailures);
    }

    /// <summary>
    /// Indicates whether the URI contains a query parameter matching <paramref name="paramName" />.
    /// </summary>
    /// <param name="paramName">The name of the query parameter to check.</param>
    /// <returns>
    /// True, if the URI contains a query parameter matching <paramref name="paramName" />;
    /// otherwise, false.
    /// </returns>
    protected bool ContainsQueryParameter(string paramName)
    {
        return _uriBuilder.ContainsQueryParameter(paramName);
    }

    /// <summary>
    /// Removes a query parameter value.
    /// </summary>
    /// <param name="paramName">The name of the query parameter.</param>
    /// <returns>Returns this instance for call chaining.</returns>
    protected T RemoveQueryParameter(string paramName)
    {
        if (string.IsNullOrWhiteSpace(paramName))
            throw new ArgumentException("Value cannot be null, empty or consist only of white space characters.", nameof(paramName));

        _uriBuilder.RemoveQueryParameter(paramName);

        return this as T;
    }

    /// <summary>
    /// Sets the query parameter value.
    /// </summary>
    /// <param name="paramName">The name of the query parameter.</param>
    /// <param name="paramValue">The value of the query parameter.</param>
    /// <returns>Returns this instance for call chaining.</returns>
    protected T SetQueryParameter(string paramName, string paramValue)
    {
        if (string.IsNullOrWhiteSpace(paramName))
            throw new ArgumentException("Value cannot be null, empty or consist only of white space characters.", nameof(paramName));

        if (string.IsNullOrWhiteSpace(paramValue))
            throw new ArgumentException("Value cannot be null, empty or consist only of white space characters.", nameof(paramValue));

        _uriBuilder.AddQueryParameter(paramName, paramValue);

        return this as T;
    }
}