
using Moq;
using OnlineServices.Shared.Enumerations;
using OnlineServices.Shared.Exceptions;
using System;
using TranslationServices.DataLayer.ServiceAgents.Domain;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;
using TranslationServices.DataLayer.ServiceAgents.TranslationAgents;
using Xunit;

namespace TranslationServices.DataLayer.ServiceAgentsTests
{
    public class AzureCognitiveAgent_TranslateTests
    {
        [Theory]
        //[InlineData(Language.English, "Test", Language.French, "Test")] //TestOfTheTest... without the logic.
        [InlineData(Language.English, "The rough sea makes him nauseous.", Language.French, "La mer agitée le rend nauséeux.")]
        [InlineData(Language.English, "Do you see that man there in that photo?", Language.Dutch, "Zie je die man daar op die foto?")]
        [InlineData(Language.French, "Maman, donne-moi un peu de lait, s'il te plaît.", Language.English, "Mommy, please give me some milk.")]
        [InlineData(Language.French, "Jouer au papa et à la maman.", Language.Dutch, "Het spelen van mama en papa.")]
        [InlineData(Language.Dutch, "Dat is niet eerlijk!", Language.English, "That's not fair!")]
        [InlineData(Language.Dutch, "Ga je met me mee, mis?", Language.French, "Tu viens avec moi, mademoiselle ?")]
        public void Translate_ShouldTranslate_WhenValidSentenceIsProvided(Language FromLangue, string StringToTranslate, Language ToLangue, string StringTranlated)
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();

            ITRSTranslationServiceV2 TranslatorToTest = new AzureCognitiveAgent(mockILogger.Object, TestHelper.AzCognitiveArgs);

            //ACT
            var args = new TranslationArgs
            {
                TextToTranslate = StringToTranslate,
                OriginalLanguage = FromLangue,
                RequestedLanguages = new Language[] { ToLangue }
            };
            var AzCognitiveTranslatedSentence = TranslatorToTest.Translate(args);

            //ASSERT
            Console.WriteLine($"Original: {StringToTranslate}");
            Assert.Equal(ToLangue, AzCognitiveTranslatedSentence[0].Item1);
            Assert.Equal(StringTranlated, AzCognitiveTranslatedSentence[0].Item2);
            
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void Translate_ThrowsArgumentNullException_WhenStringToTranslateIsNull()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();

            ITRSTranslationServiceV2 TranslatorToTest = new AzureCognitiveAgent(mockILogger.Object, TestHelper.AzCognitiveArgs);
            var args = new TranslationArgs
            {
                TextToTranslate = null,
                OriginalLanguage = Language.Dutch,
                RequestedLanguages = new Language[] { Language.English }
            };

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => TranslatorToTest.Translate(args));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Translate_ThrowsArgumentNullException_WhenStringToTranslateIsEmpty()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();

            ITRSTranslationServiceV2 TranslatorToTest = new AzureCognitiveAgent(mockILogger.Object, TestHelper.AzCognitiveArgs);
            var args = new TranslationArgs
            {
                TextToTranslate = "",
                OriginalLanguage = Language.English,
                RequestedLanguages = new Language[] { Language.French }
            };

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => TranslatorToTest.Translate(args));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Translate_ThrowsArgumentNullException_WhenStringToTranslateIsWhiteSpace()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();

            ITRSTranslationServiceV2 TranslatorToTest = new AzureCognitiveAgent(mockILogger.Object, TestHelper.AzCognitiveArgs);
            var args = new TranslationArgs
            {
                TextToTranslate = "   ",
                OriginalLanguage = Language.French,
                RequestedLanguages = new Language[] { Language.Dutch }
            };

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => TranslatorToTest.Translate(args));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Translate_ThrowsArgumentException_WhenFromLangueEqualsToLangue()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();


            ITRSTranslationServiceV2 TranslatorToTest = new AzureCognitiveAgent(mockILogger.Object, TestHelper.AzCognitiveArgs);
            var args = new TranslationArgs
            {
                TextToTranslate = "Het witte paard van Napoleon.",
                OriginalLanguage = Language.Dutch,
                RequestedLanguages = new Language[] { Language.Dutch }
            };

            //ACT & ASSERT
            Assert.Throws<ArgumentException>(() => TranslatorToTest.Translate(args));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Translate_ThrowsArgumentOutOfRange_WhenFromLangueIsNotDefinedInEnum()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();

            ITRSTranslationServiceV2 TranslatorToTest = new AzureCognitiveAgent(mockILogger.Object, TestHelper.AzCognitiveArgs);
            var args = new TranslationArgs
            {
                TextToTranslate = "こんにちは",
                OriginalLanguage = (Language)50,
                RequestedLanguages = new Language[] { Language.Dutch }
            }; 

            //ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => TranslatorToTest.Translate(args));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Translate_ThrowsArgumentOutOfRange_WhenToLangueIsNotDefinedInEnum()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();

            ITRSTranslationServiceV2 TranslatorToTest = new AzureCognitiveAgent(mockILogger.Object, TestHelper.AzCognitiveArgs);
            var args = new TranslationArgs
            {
                TextToTranslate = "Réduit la sensibilité cutanée.",
                OriginalLanguage = Language.Dutch,
                RequestedLanguages = new Language[] { (Language)50 }
            }; 

            //ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => TranslatorToTest.Translate(args));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }
    }
}
