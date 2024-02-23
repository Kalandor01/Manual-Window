using System.Diagnostics.Tracing;

namespace CleanWpfApp
{
    /// <summary>
    /// Registers provider for TraceLogging
    /// </summary>
    internal static class TraceLoggingProvider
    {
        private static EventSource _logger;
        private static readonly object _lockObject = new();

        /// <summary>
        /// CleanWpfApp provider name
        /// </summary>
        private static readonly string ProviderName = "ManualWindow.CleanWpfApp";

        /// <summary>
        /// Registers the provider and returns the instance
        /// </summary>
        /// <returns>EventSource logger if successful, null otherwise</returns>
        internal static EventSource GetProvider()
        {
            if (_logger == null)
            {
                lock (_lockObject)
                {
                    if (_logger == null)
                    {
                        try
                        {
                            _logger = new TelemetryEventSource(ProviderName);
                        }
                        catch (ArgumentException)
                        {
                            // do nothing as we expect _logger to be null in case exception
                        }
                    }
                }
            }
            return _logger;
        }
    }
}
