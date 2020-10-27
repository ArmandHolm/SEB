using System;

namespace SEB.Tests
{
    class Configuration
    {
        public static readonly TimeSpan DefaultBrowserDriverTimeout = TimeSpan.FromSeconds(120);

        public static TimeSpan DefaultElementStatusCheckTimeout = TimeSpan.FromSeconds(90);

        public static readonly TimeSpan DefaultPageLoadCheckStabilizationTimeout = TimeSpan.FromSeconds(2);
    }
}
