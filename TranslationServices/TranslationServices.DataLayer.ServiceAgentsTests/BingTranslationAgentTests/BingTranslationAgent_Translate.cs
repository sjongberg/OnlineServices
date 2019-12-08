
using Moq;
using OnlineServices.Shared.Enumerations;
using OnlineServices.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using TranslationServices.DataLayer.ServiceAgents;
using Xunit;

namespace TranslationServices.DataLayer.ServiceAgentsTests
{
    public class BingTranslationAgent_Translate
    {
        [Theory]
        [InlineData(Language.English, "The rough sea makes him nauseous.", Language.French, "La mer agitée lui donne la nausée.")]
        [InlineData(Language.English, "Do you see that man there in that photo?", Language.Dutch, "Zie je die man daar op die foto?")]
        [InlineData(Language.French, "Maman, donne-moi un peu de lait, s'il te plaît.", Language.English, "Mom, give me some milk, please.")]
        [InlineData(Language.French, "Jouer au papa et à la maman.", Language.Dutch, "Speel papa en mama.")]
        [InlineData(Language.Dutch, "Dat is niet eerlijk!", Language.English, "That's not fair!")]
        [InlineData(Language.Dutch, "Tot ziens mevrouw", Language.French, "Au revoir, mademoiselle!")]
        public void Translate_ShouldTranslate_WhenValidSentenceIsProvided(Language FromLangue, string StringToTranslate, Language ToLangue, string StringTranlated)
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();

            ITRSTranslationService TranslatorToTest = new BingTranslationAgent(mockILogger.Object, TestHelper.BingAPIKey());

            //ACT
            var BingTranslatedSentence = TranslatorToTest.Translate(StringToTranslate, FromLangue, ToLangue);

            //ASSERT
            Assert.Equal(StringTranlated, BingTranslatedSentence);
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void Translate_ThrowsArgumentNullException_WhenStringToTranslateIsNull()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();

            ITRSTranslationService TranslatorToTest = new BingTranslationAgent(mockILogger.Object, TestHelper.BingAPIKey());
            string StringToTranslate = null;
            var FromLangue = Language.Dutch;
            var ToLangue = Language.English;

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => TranslatorToTest.Translate(StringToTranslate, FromLangue, ToLangue));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Translate_ThrowsArgumentNullException_WhenStringToTranslateIsEmpty()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();

            ITRSTranslationService TranslatorToTest = new BingTranslationAgent(mockILogger.Object, TestHelper.BingAPIKey());
            string StringToTranslate = "";
            var FromLangue = Language.English;
            var ToLangue = Language.French;

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => TranslatorToTest.Translate(StringToTranslate, FromLangue, ToLangue));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Translate_ThrowsArgumentNullException_WhenStringToTranslateIsWhiteSpace()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();

            ITRSTranslationService TranslatorToTest = new BingTranslationAgent(mockILogger.Object, TestHelper.BingAPIKey());
            string StringToTranslate = "   ";
            var FromLangue = Language.French;
            var ToLangue = Language.Dutch;

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => TranslatorToTest.Translate(StringToTranslate, FromLangue, ToLangue));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Translate_ThrowsArgumentException_WhenFromLangueNotEqualsToLangue()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();

            ITRSTranslationService TranslatorToTest = new BingTranslationAgent(mockILogger.Object, TestHelper.BingAPIKey());
            string StringToTranslate = "Het witte paard van Napoleon.";
            var FromLangue = Language.Dutch;
            Language ToLangue = Language.Dutch;

            //ACT & ASSERT
            Assert.Throws<ArgumentException>(() => TranslatorToTest.Translate(StringToTranslate, FromLangue, ToLangue));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Translate_ThrowsArgumentOutOfRange_WhenFromLangueIsNotDefinedInEnum()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();

            ITRSTranslationService TranslatorToTest = new BingTranslationAgent(mockILogger.Object, TestHelper.BingAPIKey());
            string StringToTranslate = "こんにちは";
            Language FromLangue = (Language)50;
            var ToLangue = Language.Dutch;

            //ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => TranslatorToTest.Translate(StringToTranslate, FromLangue, ToLangue));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Translate_ThrowsArgumentOutOfRange_WhenToLangueIsNotDefinedInEnum()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();

            ITRSTranslationService TranslatorToTest = new BingTranslationAgent(mockILogger.Object, TestHelper.BingAPIKey());
            string StringToTranslate = "Réduit la sensibilité cutanée.";
            var FromLangue = Language.Dutch;
            Language ToLangue = (Language)50;

            //ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => TranslatorToTest.Translate(StringToTranslate, FromLangue, ToLangue));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }
    }
}
