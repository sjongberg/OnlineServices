using OnlineServices.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using TranslationServices.DataLayer.ServiceAgents.Domain;
using TranslationServices.DataLayer.ServiceAgents.Extensions;
using Xunit;

namespace TranslationServices.DataLayer.ServiceAgentsTests.Extensions
{
    public class TranslationArgsExtentionsTests
    {

        //TODO THROW TEST!!! WHEN FROM NL IS TO NL @@@
        [Fact]
        public void ComposeRoute_ReturnsAWellFormatedRoute_WhenValidArgsIsProvided()
        {
            //ARRANGE
            var args = new TranslationArgs
            {
                TextToTranslate = "Valid string to translate",
                OriginalLanguage = Language.English,
                RequestedLanguages = new Language[] { Language.Dutch }
            };

            var composedRouteToAssert = args.ComposeRoute(TestHelper.MockILogger().Object);

            Assert.Equal("&from=en&to=nl", composedRouteToAssert);
        }

        [Fact]
        public void ComposeRoute_ReturnsAWellFormatedRoute_WhenValidArgsIsProvidedMultipleResquested()
        {
            //ARRANGE
            var args = new TranslationArgs
            {
                TextToTranslate = "Valid string to translate",
                OriginalLanguage = Language.English,
                RequestedLanguages = new Language[] { Language.Dutch, Language.French }
            };

            var composedRouteToAssert = args.ComposeRoute(TestHelper.MockILogger().Object);

            Assert.Equal("&from=en&to=nl&to=fr", composedRouteToAssert);
        }
        [Fact]
        public void ComposeRoute_ReturnsAWellFormatedRouteWITHOUTDOUBLES_WhenValidArgsIsProvidedMultipleResquested()
        {
            //ARRANGE
            var args = new TranslationArgs
            {
                TextToTranslate = "Valid string to translate",
                OriginalLanguage = Language.English,
                RequestedLanguages = new Language[] { Language.Dutch, Language.French, Language.French }
            };

            var composedRouteToAssert = args.ComposeRoute(TestHelper.MockILogger().Object);

            Assert.Equal("&from=en&to=nl&to=fr", composedRouteToAssert);
        }
        [Fact]
        public void ComposeRoute_ReturnsAWellFormatedRouteWITHOUTtoEqualsFrom_WhenValidArgsIsProvidedMultipleResquested()
        {
            //ARRANGE
            var args = new TranslationArgs
            {
                TextToTranslate = "Valid string to translate",
                OriginalLanguage = Language.English,
                RequestedLanguages = new Language[] { Language.Dutch, Language.English, Language.French }
            };

            var composedRouteToAssert = args.ComposeRoute(TestHelper.MockILogger().Object);

            Assert.Equal("&from=en&to=nl&to=fr", composedRouteToAssert);
        }
    }
}
