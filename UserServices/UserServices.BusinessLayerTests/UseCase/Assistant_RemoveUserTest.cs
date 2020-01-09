using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using RegistrationServices.BusinessLayer.UseCase;
using Moq;
using OnlineServices.Shared.Exceptions;
using RegistrationServices.BusinessLayer;
using OnlineServices.Shared.RegistrationServices.Interface;
using OnlineServices.Shared.RegistrationServices.TransferObject;

namespace RegistrationServices.BusinessLayerTests.UseCase
{
    [TestClass]
    public class Assistant_RemoveUserTest
    {
        Mock<IRSUnitOfWork> MockUofW = new Mock<IRSUnitOfWork>();
        Mock<IRSUserRepository> MockUserRepository = new Mock<IRSUserRepository>();
        //Mock<ISessionRepository> MockSessionRepository = new Mock<ISessionRepository>();

        [TestMethod]
        public void RemoveUser_ReturnsTrue_WhenUserIsProvidedAndRemovedFromDB_Test()
        {
            MockUserRepository.Setup(x => x.Remove(It.IsAny<UserTO>()));
            MockUofW.Setup(x => x.UserRepository).Returns(MockUserRepository.Object);

            var assistant = new Assistant(MockUofW.Object);
            var userToRemove = new UserTO { ID = 1, Name = "Enrique", IsActivated = true };

            //Assert
            Assert.IsTrue(assistant.RemoveUser(userToRemove));

        }


    }
}
