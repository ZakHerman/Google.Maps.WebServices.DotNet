using System;
using System.Net;
using System.Net.Http;
using Polly;
using Polly.CircuitBreaker;
using Polly.Extensions.Http;
using Polly.Retry;

namespace Google.Maps.WebServices.Internals
{
    internal static class PolicyBuilder
    {
        private static readonly Random _rng = new Random();

        internal static AsyncCircuitBreakerPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(x => x.StatusCode == (HttpStatusCode)429) // Too Many Requests
                .AdvancedCircuitBreakerAsync(0.1, TimeSpan.FromSeconds(60), 100, TimeSpan.FromSeconds(10));
        }

        internal static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(x => x.StatusCode == (HttpStatusCode)429) // Too Many Requests
                .WaitAndRetryAsync(3, retryAttempt =>
                {
                    double jitter = _rng.NextDouble() + 0.5;
                    double delay = Math.Pow(2, retryAttempt) * jitter * 100;
                    return TimeSpan.FromMilliseconds(delay);
                });
        }
    }
}
