using Moq;
using Serilog;
using System;
using TranslationServices.BusinessLayer.UseCases;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;
using Xunit;

namespace TranslationServices.BusinessLayerTests.UseCases
{
    public class OnlineServicesSystem_CTOR
    {
        [Fact]
        public void CTOR_ShouldInstaciate_WhenValidInjectionIsProvided()
        {
            var mockILogger = new Mock<ILogger>();
            var mockITRSTranslationService = new Mock<ITRSTranslationServiceV1>();

            var sut = new OnlineServicesSystem(mockILogger.Object, mockITRSTranslationService.Object);
            
            Assert.NotNull(sut);
            mockILogger.Verify(x=>x.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void CTOR_ThrowsException_WhenNullInjectionIsProvided()
        {
            Assert.Throws<ArgumentNullException>(()=> new OnlineServicesSystem(null, null));
        }

        [Fact]
        public void CTOR_ShouldInstaciate_WhenNullILoggerIsProvided()
        {
            ILogger iLogger = null;
            var mockITRSTranslationService = new Mock<ITRSTranslationServiceV1>();

            Assert.Throws<ArgumentNullException>(() => new OnlineServicesSystem(iLogger, mockITRSTranslationService.Object));
        }

        [Fact]
        public void CTOR_ShouldInstaciate_WhenNullITRSTranslationServiceIsProvided()
        {
            var mockILogger = new Mock<ILogger>();
            ITRSTranslationServiceV1 iTRSTranslationService = null;

            Assert.Throws<ArgumentNullException>(() => new OnlineServicesSystem(mockILogger.Object, iTRSTranslationService));
            mockILogger.Verify(x=>x.Error(It.IsAny<string>()), Times.Once);
        }
    }
}
