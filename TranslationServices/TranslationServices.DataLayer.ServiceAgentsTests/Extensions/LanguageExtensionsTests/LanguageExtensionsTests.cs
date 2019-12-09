using OnlineServices.Shared.Enumerations;
using OnlineServices.Shared.Exceptions;
using Xunit;

namespace TranslationServices.DataLayer.ServiceAgents.Extensions
{
    public class LanguageExtensionsTests
    {
        [Theory]
        [InlineData(Language.English, "en")]
        [InlineData(Language.French, "fr")]
        [InlineData(Language.Dutch, "nl")]
        public void ToLanguageCode_RenturnsEnglish_WhenLanguageEnglishIsProvided(Language LanguageEnumToConvert, string ExpectedLanguageCode)
        {
            var ActualLanguageCode = LanguageEnumToConvert.ToLanguageCode();

            Assert.Equal(ExpectedLanguageCode, ActualLanguageCode);
        }

        [Fact]
        public void ToLanguageCode_ThrowsLanguageNotSupported_WhenInvalidLanguageEnglishIsProvided()
        {
            var LanguageEnumToConvert = (Language)50;

            Assert.Throws<LanguageNotSupportedException>(()=> LanguageEnumToConvert.ToLanguageCode());
        }
    }
}
