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
    public class OnlineServicesSystem_GetTranslation
    {
        [Fact]
        public void GetTranslation_ShouldNotTranslateEnglish_WhenValidParamIsProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var EnglishSource = "English Source String";

            //ACT
            var translated = translationUC.GetTranslation("FakeApiKey", EnglishSource, Language.English);

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
        public void GetTranslation_ShouldNotTranslateFrench_WhenValidParamIsProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var FrenchSource = "French Source String";

            //ACT
            var translated = translationUC.GetTranslation("FakeApiKey", FrenchSource, Language.French);

            //ASSERT
            Assert.NotNull(translated);
            Assert.Equal(TestHelper.EnglishTranslated, translated.ToString(Language.English));
            Assert.Equal(FrenchSource, translated.ToString(Language.French));
            Assert.Equal(TestHelper.DutchTranslated, translated.ToString(Language.Dutch));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()),
                Times.Exactly(Enum.GetNames(typeof(Language)).Count() - 1));
            mockILogger.Verify(x=>x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void GetTranslation_ShouldNotTranslateDutch_WhenValidParamIsProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var DutchSource = "Dutch Source String";

            //ACT
            var translated = translationUC.GetTranslation("FakeApiKey", DutchSource, Language.Dutch);

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
        public void GetTranslation_ThrowsIsNullOrWhiteSpaceException_WhenAPIKeyIsNotProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var DutchSource = "Dutch Source String";

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => translationUC.GetTranslation("", DutchSource, Language.Dutch));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()), Times.Never);
            mockILogger.Verify(x=>x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetTranslation_ThrowsIsNullOrWhiteSpaceException_WhenMultiLanguageStringIsNULL()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            string SringToTranslate = null;

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => translationUC.GetTranslation("FakeApiKey", SringToTranslate, Language.Dutch));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()), Times.Never);
            mockILogger.Verify(x=>x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetTranslation_ThrowsIsNullOrWhiteSpaceException_WhenSourceStringToTranslateIsNotProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            string SringToTranslate = "   ";

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => translationUC.GetTranslation("FakeApiKey", SringToTranslate, Language.Dutch));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()), Times.Never);
            mockILogger.Verify(x=>x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetTranslation_ThrowsIsNullOrWhiteSpaceException_WhenLanguageIsNotProvided()
        {
            //ARRANGE
            var mockILogger = TestHelper.MakeILogger();
            var mockITRSTranslationService = TestHelper.MakeITRSTranslationService();

            var translationUC = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            var DutchSource = "Dutch Source String";

            //ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => translationUC.GetTranslation("FakeApiKey", DutchSource, (Language)50));
            mockITRSTranslationService.Verify(x => x.Translate(It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<Language>()), Times.Never);
            mockILogger.Verify(x=>x.Error(It.IsAny<string>()), Times.Once);
        }
    }
}
