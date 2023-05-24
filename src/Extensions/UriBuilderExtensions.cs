using System;
using System.Collections.Specialized;
using System.Web;

namespace Google.Maps.WebServices.Extensions;

internal static class UriBuilderExtensions
{
    /// <summary>
    /// Adds the specified parameter to the Query String.
    /// </summary>
    /// <param name="uriBuilder"></param>
    /// <param name="paramName">Name of the parameter to add.</param>
    /// <param name="paramValue">Value for the parameter to add.</param>
    /// <returns>Url with added parameter.</returns>
    internal static UriBuilder AddQueryParameter(this UriBuilder uriBuilder, string paramName, string paramValue)
    {
        NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query[paramName] = paramValue;
        uriBuilder.Query = query.ToString() ?? throw new InvalidOperationException(nameof(query));

        return uriBuilder;
    }

    internal static bool ContainsQueryParameter(this UriBuilder uriBuilder, string paramName)
    {
        NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);

        return query[paramName] != null;
    }

    internal static UriBuilder RemoveQueryParameter(this UriBuilder uriBuilder, string paramName)
    {
        NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query.Remove(paramName);
        uriBuilder.Query = query.ToString() ?? throw new InvalidOperationException(nameof(query));

        return uriBuilder;
    }
}