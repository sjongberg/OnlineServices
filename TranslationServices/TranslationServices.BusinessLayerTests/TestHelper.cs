using Moq;
using OnlineServices.Shared.Enumerations;
using Serilog;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;

namespace TranslationServices.BusinessLayerTests
{
    public static class TestHelper
    {
        public const string EnglishTranslated = "EnglishTranslated";
        public const string FrenchTranslated = "FrenchTranslated";
        public const string DutchTranslated = "DutchTranslated";

        public static Mock<ITRSTranslationServiceV1> MakeITRSTranslationService()
        {
            var mockITRSTranslationService = new Mock<ITRSTranslationServiceV1>();

            mockITRSTranslationService
                .Setup(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), Language.English))
                .Returns(EnglishTranslated);

            mockITRSTranslationService
                .Setup(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), Language.French))
                .Returns(FrenchTranslated);

            mockITRSTranslationService
                .Setup(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), Language.Dutch))
                .Returns(DutchTranslated);

            return mockITRSTranslationService;
        }

        public static Mock<ILogger> MakeILogger()
        {
            var mockILogger = new Mock<ILogger>();

            mockILogger.Setup(x => x.Error(It.IsAny<string>()));

            return mockILogger;
        }
    }
}
