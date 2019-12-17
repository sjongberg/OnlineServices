using Moq;
using Serilog;
using TranslationServices.DataLayer.ServiceAgents.Domain;

namespace TranslationServices.DataLayer.ServiceAgentsTests
{
    public static class TestHelper
    {
        public static string GoogleAPIKey()
        {
            return @"C:\TFS\OnlineServices-d9921f8e5f21.json";
        }

        public static AzureCognitiveArgs AzCognitiveArgs
            => new AzureCognitiveArgs();

        public static Mock<ILogger> MockILogger()
        {
            var mockILogger =  new Mock<ILogger>();
            mockILogger.Setup(x => x.Error(It.IsAny<string>())).Verifiable();
            return mockILogger;
        }
    }
}
