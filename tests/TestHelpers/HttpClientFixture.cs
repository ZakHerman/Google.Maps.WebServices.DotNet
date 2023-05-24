using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;

namespace Google.Maps.WebServices.Tests.TestHelpers;

public class HttpClientFixture
{
    private readonly Mock<HttpMessageHandler> _httpHandlerMock;

    public HttpClientFixture()
    {
        _httpHandlerMock = new Mock<HttpMessageHandler>();
    }

    public async Task<HttpClient> CreateHttpClientAsync(string resourceFileName)
    {
        if (string.IsNullOrWhiteSpace(resourceFileName))
            throw new ArgumentException("Value cannot be null, empty or white space", nameof(resourceFileName));

        string path = Path.Combine(AppContext.BaseDirectory, $"Resources/{resourceFileName}");
        string json = await File.ReadAllTextAsync(path);

        _httpHandlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                Content = new StringContent(json)
            });

        return new HttpClient(_httpHandlerMock.Object);
    }
}