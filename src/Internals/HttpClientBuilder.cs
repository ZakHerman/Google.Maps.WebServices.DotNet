using System;
using System.Net.Http;

namespace Google.Maps.WebServices.Internals
{
    internal static class HttpClientBuilder
    {
        internal static HttpClient CreateClient()
        {
            var socketsHandler = new StandardSocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(10),
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(5),
                MaxConnectionsPerServer = 10
            };

            return new HttpClient(socketsHandler);
        }
    }
}
