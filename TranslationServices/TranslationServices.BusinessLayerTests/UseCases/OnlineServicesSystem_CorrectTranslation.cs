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
    public class OnlineServicesSystem_CorrectTranslation
    {
        [Fact]
        public void CorrectTranslation_ShouldNotTranslateEnglish_WhenValidParamIsProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var EnglishSource = "English Source String";
            var MLSToCorrect = new MultiLanguageString(EnglishSource, "Not a good translation", "Some wrong DutchString");

            //ACT
            var translated = translationUC.CorrectTranslation("FakeApiKey", MLSToCorrect, Language.English);

            //ASSERT
            Assert.NotNull(translated);
            Assert.Equal(EnglishSource, translated.ToString(Language.English));
            Assert.Equal(TestHelper.FrenchTranslated, translated.ToString(Language.French));
            Assert.Equal(TestHelper.DutchTranslated, translated.ToString(Language.Dutch));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()),
                Times.Exactly(Enum.GetNames(typeof(Language)).Count() - 1));
            mockILogger.Verify(x=>x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void CorrectTranslation_ShouldNotTranslateFrench_WhenValidParamIsProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var FrenchSource = "French Source String";
            var MLSToCorrect = new MultiLanguageString("Not a good translation", FrenchSource, "Some wrong DutchString");

            //ACT
            var translated = translationUC.CorrectTranslation("FakeApiKey", MLSToCorrect, Language.French);

            //ASSERT
            Assert.NotNull(translated);
            Assert.Equal(TestHelper.EnglishTranslated, translated.ToString(Language.English));
            Assert.Equal(FrenchSource, translated.ToString(Language.French));
            Assert.Equal(TestHelper.DutchTranslated, translated.ToString(Language.Dutch));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()),
                Times.Exactly(Enum.GetNames(typeof(Language)).Count() - 1));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void CorrectTranslation_ShouldNotTranslateDutch_WhenValidParamIsProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var DutchSource = "Dutch Source String";
            var MLSToCorrect = new MultiLanguageString("Not a good translation", "Some wrong DutchString", DutchSource);

            //ACT
            var translated = translationUC.CorrectTranslation("FakeApiKey", MLSToCorrect, Language.Dutch);

            //ASSERT
            Assert.NotNull(translated);
            Assert.Equal(TestHelper.EnglishTranslated, translated.ToString(Language.English));
            Assert.Equal(TestHelper.FrenchTranslated, translated.ToString(Language.French));
            Assert.Equal(DutchSource, translated.ToString(Language.Dutch));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()),
                Times.Exactly(Enum.GetNames(typeof(Language)).Count()-1));
            mockILogger.Verify(x=>x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void CorrectTranslation_ThrowsIsNullOrWhiteSpaceException_WhenAPIKeyIsNotProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var DutchSource = "Dutch Source String";
            var MLSToCorrect = new MultiLanguageString("Not a good translation", "Some wrong DutchString", DutchSource);

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => translationUC.CorrectTranslation("", MLSToCorrect, Language.Dutch));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()), Times.Never);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CorrectTranslation_ThrowsIsNullOrWhiteSpaceException_WhenMultiLanguageStringIsNULL()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            MultiLanguageString MLSToCorrect = null;

            //ACT & ASSERT
            Assert.Throws<ArgumentNullException>(() => translationUC.CorrectTranslation("FakeApiKey", MLSToCorrect, Language.Dutch));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()), Times.Never);
            mockILogger.Verify(x=>x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CorrectTranslation_ThrowsIsNullOrWhiteSpaceException_WhenSourceStringToTranslateIsNotProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var MLSToCorrect = new MultiLanguageString("Not a good translation", "Some wrong DutchString", "  ");

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => translationUC.CorrectTranslation("FakeApiKey", MLSToCorrect, Language.Dutch));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()), Times.Never);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CorrectTranslation_ThrowsIsNullOrWhiteSpaceException_WhenLanguageIsNotProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var DutchSource = "Dutch Source String";
            var MLSToCorrect = new MultiLanguageString("Not a good translation", "Some wrong DutchString", DutchSource);

            //ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => translationUC.CorrectTranslation("FakeApiKey", MLSToCorrect, (Language)50));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()), Times.Never);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }
    }
}
