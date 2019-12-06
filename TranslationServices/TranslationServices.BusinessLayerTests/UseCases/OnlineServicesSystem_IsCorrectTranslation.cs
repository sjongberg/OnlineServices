using Moq;
using OnlineServices.Shared.Enumerations;
using OnlineServices.Shared.Exceptions;
using OnlineServices.Shared.TranslationServices.TransfertObjects;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TranslationServices.BusinessLayer.UseCases;
using TranslationServices.DataLayer.ServiceAgents;
using Xunit;

namespace TranslationServices.BusinessLayerTests.UseCases
{
    public class OnlineServicesSystem_IsCorrectTranslation
    {
        [Fact]
        public void IsCorrectTranslation_ReturnsTrue_When_ENGLISH_IS_WellTranslated()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var EnglishSource = "English Source String";
            var MLSToCheck = new MultiLanguageString(EnglishSource, TestHelper.FrenchTranslated, TestHelper.DutchTranslated);

            //ACT
            var translated = translationUC.IsCorrectTranslation("FakeApiKey", MLSToCheck, Language.English);

            //ASSERT
            Assert.True(translated);
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()),
                Times.Exactly(Enum.GetNames(typeof(Language)).Count() - 1));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void IsCorrectTranslation_ReturnsTrue_When_FRENCH_IS_WellTranslated()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var FrenchSource = "French Source String";
            var MLSToCheck = new MultiLanguageString(TestHelper.EnglishTranslated, FrenchSource, TestHelper.DutchTranslated);

            //ACT
            var translated = translationUC.IsCorrectTranslation("FakeApiKey", MLSToCheck, Language.French);

            //ASSERT
            Assert.True(translated);
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()),
                Times.Exactly(Enum.GetNames(typeof(Language)).Count() - 1));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void IsCorrectTranslation_ReturnsTrue_When_DUTCH_IS_WellTranslated()

        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var DutchSource = "Dutch Source String";
            var MLSToCheck = new MultiLanguageString(TestHelper.EnglishTranslated, TestHelper.FrenchTranslated, DutchSource);

            //ACT
            var translated = translationUC.IsCorrectTranslation("FakeApiKey", MLSToCheck, Language.Dutch);

            //ASSERT
            Assert.True(translated);
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()),
                Times.Exactly(Enum.GetNames(typeof(Language)).Count() - 1));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void IsCorrectTranslation_ReturnsFalse_When_ENGLISH_IsNOT_WellTranslated()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var EnglishSource = "English Source String";
            var MLSToCheck = new MultiLanguageString(EnglishSource, "Not a good translation", "Some wrong DutchString");

            //ACT
            var translated = translationUC.IsCorrectTranslation("FakeApiKey", MLSToCheck, Language.English);

            //ASSERT
            Assert.False(translated);
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()),
                Times.AtMost(Enum.GetNames(typeof(Language)).Count() - 1));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void IsCorrectTranslation_ReturnsFalse_When_FRENCH_IsNOT_WellTranslated()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var FrenchSource = "French Source String";
            var MLSToCheck = new MultiLanguageString(TestHelper.EnglishTranslated, FrenchSource, "Some wrong DutchString");

            //ACT
            var translated = translationUC.IsCorrectTranslation("FakeApiKey", MLSToCheck, Language.French);

            //ASSERT
            Assert.False(translated);
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()),
                Times.AtMost(Enum.GetNames(typeof(Language)).Count() - 1));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void IsCorrectTranslation_ReturnsFalse_When_DUTCH_IsNOT_WellTranslated()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var DutchSource = "Dutch Source String";
            var MLSToCheck = new MultiLanguageString(TestHelper.EnglishTranslated, "Some wrong DutchString", DutchSource);

            //ACT
            var translated = translationUC.IsCorrectTranslation("FakeApiKey", MLSToCheck, Language.Dutch);

            //ASSERT
            Assert.False(translated);
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()),
                Times.AtMost(Enum.GetNames(typeof(Language)).Count()));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void IsCorrectTranslation_ThrowsIsNullOrWhiteSpaceException_WhenAPIKeyIsNotProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var DutchSource = "Dutch Source String";
            var MLSToCheck = new MultiLanguageString("Not a good translation", "Some wrong DutchString", DutchSource);

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => translationUC.IsCorrectTranslation("", MLSToCheck, Language.Dutch));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()), Times.Never);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void IsCorrectTranslation_ThrowsIsNullOrWhiteSpaceException_WhenMultiLanguageStringIsNULL()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            MultiLanguageString MLSToCheck = null;

            //ACT & ASSERT
            Assert.Throws<ArgumentNullException>(() => translationUC.IsCorrectTranslation("FakeApiKey", MLSToCheck, Language.Dutch));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()), Times.Never);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void IsCorrectTranslation_ThrowsIsNullOrWhiteSpaceException_WhenSourceStringToTranslateIsNotProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var MLSToCheck = new MultiLanguageString("Not a good translation", "Some wrong DutchString", "  ");

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => translationUC.IsCorrectTranslation("FakeApiKey", MLSToCheck, Language.Dutch));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()), Times.Never);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void IsCorrectTranslation_ThrowsIsNullOrWhiteSpaceException_WhenLanguageIsNotProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var DutchSource = "Dutch Source String";
            var MLSToCheck = new MultiLanguageString("Not a good translation", "Some wrong DutchString", DutchSource);

            //ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => translationUC.IsCorrectTranslation("FakeApiKey", MLSToCheck, (Language)50));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()), Times.Never);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void IsCorrectTranslation_CallsONCETranslator_When1stNOTWellTranslated_PerformanceTest()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var FrenchSource = "French Source String";
            var MLSToCheck = new MultiLanguageString("What's up bro?", FrenchSource, TestHelper.DutchTranslated);

            //ACT
            var translated = translationUC.IsCorrectTranslation("FakeApiKey", MLSToCheck, Language.French);

            //ASSERT
            Assert.False(translated);
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()),
                Times.Once());
        }

        [Fact]
        public void IsCorrectTranslation_CallsTWICETranslator_When2stNOTWellTranslated_PerformanceTest()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var FrenchSource = "French Source String";
            var MLSToCheck = new MultiLanguageString(TestHelper.EnglishTranslated, FrenchSource, "blah blah blah...");

            //ACT
            var translated = translationUC.IsCorrectTranslation("FakeApiKey", MLSToCheck, Language.French);

            //ASSERT
            Assert.False(translated);
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()),
                Times.Exactly(2));
        }
    }
}
