using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using TranslationServices.DataLayer.ServiceAgents;

namespace TranslationServices.DataLayer.ServiceAgentsTests
{
    public static class TestHelper
    {
        public static string GoogleAPIKey()
        {
            return @"C:\TFS\OnlineServices-d9921f8e5f21.json";
        }

        public static string BingAPIKey()
        {
            return @"Bing Api Key";
        }

        public static Mock<ILogger> MockILogger()
        {
            return new Mock<ILogger>();
        }
    }
}
