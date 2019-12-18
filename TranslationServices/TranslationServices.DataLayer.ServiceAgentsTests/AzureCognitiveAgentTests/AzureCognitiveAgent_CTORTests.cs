using Moq;
using OnlineServices.Shared.Exceptions;
using System;
using Xunit;
using Serilog;
using TranslationServices.DataLayer.ServiceAgents.TranslationAgents;
using TranslationServices.DataLayer.ServiceAgents.Domain;

namespace TranslationServices.DataLayer.ServiceAgentsTests
{
    public class AzureCognitiveAgent_CTORTests
    {
        #region Serilog.ILogger
        [Fact]
        public void CTOR_ThrowsArgumentNullException_WhenIloggerIsNull()
        {
            //ARRANGE
            ILogger iLogger = null;
            AzureCognitiveArgs AzArg = TestHelper.AzCognitiveArgs;

            //ACT & ASSERT
            Assert.Throws<ArgumentNullException>(() => new AzureCognitiveAgent(iLogger, AzArg));
        }
        #endregion Serilog.ILogger

        #region AzureCognitiveArgs
        [Fact]
        public void CTOR_ThrowsArgumentNullException_WhenAzureCognitiveArgsIsNull()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            AzureCognitiveArgs AzArg = null;

            //ACT & ASSERT
            Assert.Throws<ArgumentNullException>(() => new AzureCognitiveAgent(mockILogger.Object, AzArg));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }
        #endregion AzureCognitiveArgs

        #region AzureCognitiveArgs.SubscriptionKey
        [Fact]
        public void CTOR_ThrowsArgumentNullException_WhenAzArgSubscriptionKeyIsNull()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            AzureCognitiveArgs AzArg = new AzureCognitiveArgs { SubscriptionKey = null };

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => new AzureCognitiveAgent(mockILogger.Object, AzArg));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CTOR_ThrowsIsNullOrWhiteSpaceException_WhenAzArgSubscriptionKeyIsEmpty()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            AzureCognitiveArgs AzArg = new AzureCognitiveArgs { SubscriptionKey = "" };

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => new AzureCognitiveAgent(mockILogger.Object, AzArg));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CTOR_ThrowsIsNullOrWhiteSpaceException_WhenSubscriptionKeyIsWhitSpace()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            AzureCognitiveArgs AzArg = new AzureCognitiveArgs { SubscriptionKey = "   " };

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => new AzureCognitiveAgent(mockILogger.Object, AzArg));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }
        #endregion SubscriptionKey

        #region AzureCognitiveArgs.EndPoint
        [Fact]
        public void CTOR_ThrowsArgumentNullException_WhenAzArgEndpointIsNull()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            AzureCognitiveArgs AzArg = new AzureCognitiveArgs { Endpoint = null };

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => new AzureCognitiveAgent(mockILogger.Object, AzArg));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CTOR_ThrowsIsNullOrWhiteSpaceException_WhenAzArgEndpointIsEmpty()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            AzureCognitiveArgs AzArg = new AzureCognitiveArgs { Endpoint = "" };

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => new AzureCognitiveAgent(mockILogger.Object, AzArg));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void CTOR_ThrowsIsNullOrWhiteSpaceException_WhenEndpointIsWhitSpace()
        {
            //ARRANGE
            var mockILogger = TestHelper.MockILogger();
            AzureCognitiveArgs AzArg = new AzureCognitiveArgs { Endpoint = "   " };

            //ACT & ASSERT
            Assert.Throws<IsNullOrWhiteSpaceException>(() => new AzureCognitiveAgent(mockILogger.Object, AzArg));
            mockILogger.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }
        #endregion Endpoint



    }
}
