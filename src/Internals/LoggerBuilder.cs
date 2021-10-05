using Microsoft.Extensions.Logging;

namespace Google.Maps.WebServices.Internals
{
    internal static class LoggerBuilder
    {
        internal static ILogger<T> CreateLogger<T>()
        {
            ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());

            return factory.CreateLogger<T>();
        }
    }
}
