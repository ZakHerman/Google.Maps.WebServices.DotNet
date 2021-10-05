using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Converters;
using Google.Maps.WebServices.Exceptions;
using Google.Maps.WebServices.Internals;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using Polly.Wrap;
using PolicyBuilder = Google.Maps.WebServices.Internals.PolicyBuilder;

namespace Google.Maps.WebServices
{
    /// <summary>
    /// The entry point for making requests against the Google Maps Web Services.
    /// </summary>
    /// <remarks>
    /// <see cref="GoogleMapsServiceClient" /> works best when you create a single instance, or one
    /// per API key, and reuse it for all your Google Maps Web Service requests.
    /// </remarks>
    public class GoogleMapsServiceClient
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        private readonly AsyncPolicyWrap<HttpResponseMessage> _policyWrap;

        private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>
            {
                new DefaultUnknownEnumConverter()
            }
        };

        /// <inheritdoc cref="GoogleMapsServiceClient(string, HttpClient)" />
        public GoogleMapsServiceClient(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("Value cannot be null, empty or white space", nameof(apiKey));

            _apiKey = apiKey;
            _httpClient = HttpClientBuilder.CreateClient();
            _policyWrap = Policy.WrapAsync(PolicyBuilder.GetRetryPolicy(), PolicyBuilder.GetCircuitBreakerPolicy());
            _logger = LoggerBuilder.CreateLogger<GoogleMapsServiceClient>();
        }

        /// <summary>
        /// Constructs an instance of the <see cref="GoogleMapsServiceClient" /> class.
        /// </summary>
        /// <param name="apiKey">The API key used to authorize requests to Google Maps Web Services.</param>
        /// <param name="httpClient">The instance of <see cref="HttpClient" />.</param>
        internal GoogleMapsServiceClient(string apiKey, HttpClient httpClient)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("Value cannot be null, empty or white space", nameof(apiKey));

            _apiKey = apiKey;
            _policyWrap = Policy.WrapAsync(PolicyBuilder.GetRetryPolicy(), PolicyBuilder.GetCircuitBreakerPolicy());
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Constructs an instance of the <see cref="GoogleMapsServiceClient" /> class for mocking.
        /// </summary>
        protected GoogleMapsServiceClient()
        { }

        /// <summary>
        /// Sends a GET request to the web service.
        /// </summary>
        /// <typeparam name="TRequest">
        /// The <see cref="GoogleMapsRequestOptions{TRequest}" /> builder class.
        /// </typeparam>
        /// <typeparam name="TResponse">The <see cref="GoogleMapsResponse{TResult}" /> class.</typeparam>
        /// <typeparam name="TResult">The Google Maps Web Service result class.</typeparam>
        /// <param name="request">The instance of the Google Maps Web Service request builder class.</param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The <see cref="GoogleMapsResponse{TResult}" /> class.</returns>
        internal async Task<GoogleMapsResponse<TResult>> GetAsync<TRequest, TResponse, TResult>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : GoogleMapsRequestOptions<TRequest>
            where TResponse : class, IResponse<TResult>
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            request.SetAuthentication(_apiKey);
            request.ValidateRequest();

            HttpResponseMessage httpResponse = await _policyWrap.ExecuteAsync(async ct => await _httpClient.GetAsync(request.Uri, ct), cancellationToken);

            return await ProcessResponseAsync<TResponse, TResult>(httpResponse);
        }

        private async Task<GoogleMapsResponse<TResult>> ProcessResponseAsync<TResponse, TResult>(HttpResponseMessage httpResponse)
            where TResponse : class, IResponse<TResult>
        {
            string responseBody = await httpResponse.Content.ReadAsStringAsync();
            TResponse googleMapsResponse = JsonConvert.DeserializeObject<TResponse>(responseBody, _serializerSettings);

            if (googleMapsResponse is null)
                throw new JsonSerializationException("Response body could not be deserialized.");

            if (!googleMapsResponse.IsSuccessful)
                GoogleMapsException.Create(googleMapsResponse.ResponseStatus, googleMapsResponse.ErrorMessage);

            return new GoogleMapsResponse<TResult>(googleMapsResponse);
        }
    }
}
